using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform leftPoint, rightPoint;
    private bool movingRight;
    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator anim;

    [SerializeField] private float moveTime, waitTime;
    private float moveCount, waitCount;

    private void Start()
    {
        leftPoint.SetParent(LevelManager.instance.movePointHolder);
        rightPoint.SetParent(LevelManager.instance.movePointHolder);
        rb = GetComponent<Rigidbody2D>();
        movingRight = true;
        spriteRenderer.flipX = true;
        moveCount = moveTime;
        anim.SetBool("isMoving", true);
    }

    private void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            if (movingRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

                if (transform.position.x > rightPoint.position.x)
                {
                    spriteRenderer.flipX = false;
                    movingRight = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

                if (transform.position.x < leftPoint.position.x)
                {
                    spriteRenderer.flipX = true;
                    movingRight = true;
                }
            }

            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
                anim.SetBool("isMoving", false);
            }
            
        }
        else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, moveTime * 1.25f);
                anim.SetBool("isMoving", true);
            }
            
        }
    }
}
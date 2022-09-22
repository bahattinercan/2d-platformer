using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private bool isGrounded;
    private bool canDoubleJump = true;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask groundLayer;

    public float knockbackLength, knockbackForce;
    private float knockbackCounter;
    public float bounceForce;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        CheckPointController.instance.SpawnPoint = transform.position;
    }

    private void Update()
    {
        if (!LevelManager.instance.isPaused)
        {
            if (knockbackCounter <= 0)
            {
                rb.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

                isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, groundLayer);

                if (isGrounded)
                {
                    canDoubleJump = true;
                }

                if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded)
                    {
                        AudioManager.instance.PlayAudio(AudioManager.AudioTypes.playerJump);
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    }
                    else
                    {
                        if (canDoubleJump)
                        {
                            AudioManager.instance.PlayAudio(AudioManager.AudioTypes.playerJump);
                            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                            canDoubleJump = false;
                        }
                    }
                }

                if (rb.velocity.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (rb.velocity.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
            }
            else
            {
                knockbackCounter -= Time.deltaTime;
                // looking right
                if (!spriteRenderer.flipX)
                {
                    rb.velocity = new Vector2(-knockbackForce, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(knockbackForce, rb.velocity.y);
                }
            }
        }
        SetAnimationValues();
    }

    private void SetAnimationValues()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY", rb.velocity.y);
    }

    public void KnockBack()
    {
        knockbackCounter = knockbackLength;
        rb.velocity = new Vector2(0, knockbackForce);
        anim.SetTrigger("hurt");
    }

    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, bounceForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }
}
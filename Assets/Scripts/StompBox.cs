using UnityEngine;

public class StompBox : MonoBehaviour
{
    [SerializeField, Range(0, 25)] private float chanceToDropCherry;
    [SerializeField, Range(0, 75)] private float chanceToDropGem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")&& !collision.isTrigger)
        {
            PlayerController.instance.Bounce();
            Instantiate(GameAssets.instance.deathVFX, collision.transform.position, Quaternion.identity);
            Destroy(collision.transform.parent.gameObject);

            int random = Random.Range(0, 100);
            //Debug.Log("random number: " + random);
            if (random <= chanceToDropCherry)
            {
                Instantiate(GameAssets.instance.cherry, collision.transform.position, Quaternion.identity);
            }
            else if (random <= chanceToDropCherry+chanceToDropGem)
            {
                Instantiate(GameAssets.instance.gem, collision.transform.position, Quaternion.identity);
            }
            AudioManager.instance.PlayAudio(AudioManager.AudioTypes.enemyExplode);
        }
    }
}
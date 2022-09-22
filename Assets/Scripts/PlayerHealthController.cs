using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    [SerializeField] private int currentHealth, maxHealth;
    [SerializeField] private float invinsibleLength;
    private float invinsibleCounter;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (invinsibleCounter > 0)
        {
            invinsibleCounter -= Time.deltaTime;
            if (invinsibleCounter <= 0)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
            }
        }
    }

    public void TakeDamage(int damage = 1)
    {
        if (invinsibleCounter <= 0)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Instantiate(GameAssets.instance.deathVFX, transform.position, Quaternion.identity);
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invinsibleCounter = invinsibleLength;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, .65f);
                PlayerController.instance.KnockBack();
                AudioManager.instance.PlayAudio(AudioManager.AudioTypes.playerHurt);
            }
            UIController.instance.UpdateHeartDisplay(currentHealth);
        }
    }

    public void Heal(int heal)
    {
        currentHealth = Mathf.Clamp(currentHealth + heal, 0, maxHealth);
        UIController.instance.UpdateHeartDisplay(currentHealth);
    }

    public void HealMax()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateHeartDisplay(currentHealth);
    }

    public bool NeedHeal()
    {
        if (currentHealth == maxHealth)
            return false;
        else
            return true;
    }
}
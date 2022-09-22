using UnityEngine;

public class Pickup : MonoBehaviour
{
    enum pickupTypes
    {
        gem,
        heal,
    }

    [SerializeField] private pickupTypes pickupType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (pickupType)
            {
                case pickupTypes.gem:
                    LevelManager.instance.AddGems();
                    Instantiate(GameAssets.instance.pickupVFX, transform.position, Quaternion.identity);
                    AudioManager.instance.PlayAudio(AudioManager.AudioTypes.pickupGem);
                    Destroy(gameObject);                    
                    break;
                case pickupTypes.heal:
                    if (PlayerHealthController.instance.NeedHeal())
                    {
                        PlayerHealthController.instance.Heal(1);
                        Instantiate(GameAssets.instance.pickupVFX, transform.position, Quaternion.identity);
                        AudioManager.instance.PlayAudio(AudioManager.AudioTypes.pickupHealth);
                        Destroy(gameObject);
                    }                        
                    break;
                default:
                    break;
            }
            
            
        }
    }
}
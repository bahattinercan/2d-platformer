using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum AudioTypes
    {
        bossHit,
        bossImpact,
        bossShot,
        enemyExplode,
        levelSelected,
        mapMovement,
        pickupGem,
        pickupHealth,
        playerDeath,
        playerHurt,
        playerJump,
        warpJingle
    }

    public static AudioManager instance;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioSource bgAudioSource;
    [Space]
    [SerializeField] private AudioClip bossHit;

    [SerializeField] private AudioClip bossImpact;
    [SerializeField] private AudioClip bossShot;
    [SerializeField] private AudioClip enemyExplode;
    [SerializeField] private AudioClip levelSelected;
    [SerializeField] private AudioClip mapMovement;
    [SerializeField] private AudioClip pickupGem;
    [SerializeField] private AudioClip pickupHealth;
    [SerializeField] private AudioClip playerDeath;
    [SerializeField] private AudioClip playerHurt;
    [SerializeField] private AudioClip playerJump;
    [SerializeField] private AudioClip warpJingle;

    private void Awake()
    {
        instance = this;
    }

    public void PlayAudio(AudioTypes audioTypes)
    {
        AudioClip audioClip;
        switch (audioTypes)
        {
            case AudioTypes.bossHit:
                audioClip = bossHit;
                break;
            case AudioTypes.bossImpact:
                audioClip = bossImpact;
                break;
            case AudioTypes.bossShot:
                audioClip = bossShot;
                break;
            case AudioTypes.enemyExplode:
                audioClip = enemyExplode;
                break;
            case AudioTypes.levelSelected:
                audioClip = levelSelected;
                break;
            case AudioTypes.mapMovement:
                audioClip = mapMovement;
                break;
            case AudioTypes.pickupGem:
                audioClip = pickupGem;
                break;
            case AudioTypes.pickupHealth:
                audioClip = pickupHealth;
                break;
            case AudioTypes.playerDeath:
                audioClip = playerDeath;
                break;
            case AudioTypes.playerHurt:
                audioClip = playerHurt;
                break;
            case AudioTypes.playerJump:
                audioClip = playerJump;
                break;
            case AudioTypes.warpJingle:
                audioClip = warpJingle;
                break;
            default:
                Debug.Log("böyle bir audio type yoktur");
                audioClip = playerHurt;
                break;
        }
        foreach (AudioSource source in audioSources)
        {
            if (!source.isPlaying)
            {
                source.volume = .5f;
                source.pitch = Random.Range(0.9f, 1.1f);
                source.PlayOneShot(audioClip);
                return;
            }
        }
    }
}
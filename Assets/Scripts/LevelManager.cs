using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private float waitToRespawn;
    public int gems;
    public Transform movePointHolder;
    public bool isPaused;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetGems(0);
        isPaused = false;
    }

    public void AddGems(int value=1)
    {
        gems += value;
        UIController.instance.UpdateGemDisplay(gems);
    }

    public void SetGems(int value)
    {
        gems = value;
        UIController.instance.UpdateGemDisplay(gems);
    }

    public void TakeGems(int value)
    {
        gems -= value;
        UIController.instance.UpdateGemDisplay(gems);
    }

    public void RespawnPlayer()
    {
        PlayerController.instance.gameObject.SetActive(false);
        Invoke("SetActivePlayer", waitToRespawn);
        AudioManager.instance.PlayAudio(AudioManager.AudioTypes.playerDeath);
    }

    private void SetActivePlayer()
    {
        PlayerController.instance.transform.position = CheckPointController.instance.SpawnPoint + (Vector3)Vector2.up;
        PlayerController.instance.gameObject.SetActive(true);
        PlayerHealthController.instance.HealMax();
    }
}
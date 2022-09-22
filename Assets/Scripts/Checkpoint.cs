using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite checkpointOn, checkpointOff;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckPointController.instance.DeactivateCheckpoints();
            spriteRenderer.sprite = checkpointOn;
            CheckPointController.instance.SpawnPoint = transform.position;
        }
    }

    public void ResetCheckPoint()
    {
        spriteRenderer.sprite = checkpointOff;
    }
}
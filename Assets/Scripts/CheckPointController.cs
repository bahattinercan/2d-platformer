using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;

    private Checkpoint[] checkpoints;
    private Vector3 spawnPoint;

    public Vector3 SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
    }

    public void DeactivateCheckpoints()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckPoint();
        }
    }
}
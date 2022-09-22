using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int currentpoint;
    [SerializeField] private Transform targetPlatform;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private void Update()
    {
        targetPlatform.position = Vector3.MoveTowards(targetPlatform.position, points[currentpoint].position, MoveSpeed * Time.deltaTime);
        if(Vector3.Distance(targetPlatform.position,points[currentpoint].position) < .05f)
        {
            currentpoint++;
            if (currentpoint >= points.Length)
            {
                currentpoint = 0;
            }
        }
    }
}
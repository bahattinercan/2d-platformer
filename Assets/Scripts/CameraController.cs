using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Transform farBackground, middleBackground;
    private Vector2 lastPos;
    [SerializeField] private float minHeight, maxHeight;

    // Start is called before the first frame update
    private void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y); 
        farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0);
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0) * .5f;

        lastPos = transform.position;
    }
}
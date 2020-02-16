
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 offset;
    public float smoothSpeed;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = playerPosition.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothPosition;
    }
}


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 offset;
    public float smoothSpeed;
    float intensity;
    float duration;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = playerPosition.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothPosition;
    }

    private void Update()
    {
        if(duration > 0)
        {
            transform.position = Vector3.Lerp(transform.position, playerPosition.position + offset, smoothSpeed) + Random.insideUnitSphere * intensity;
            duration -= Time.deltaTime;
        }
    }

    public void CameraShake(float i, float d)
    {
        duration = d;
        intensity = i;
    }
}

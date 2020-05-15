using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekcpointPeur : MonoBehaviour
{
    public GameObject camera2D;
    public float cameraSize;
    public Vector3 newCameraPosition;

    public GameObject enemyPeur;
    public Vector3 enemyPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            camera2D.GetComponent<Camera>().orthographicSize = cameraSize;
            camera2D.GetComponent<CameraFollow>().offset = newCameraPosition;
            enemyPeur.transform.position = enemyPosition;
        }
    }
}        

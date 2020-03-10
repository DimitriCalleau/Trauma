using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMove : MonoBehaviour
{
    public float moveLenght;
    public float moveSpeed;
    public Vector3 initTransform;

    // Start is called before the first frame update
    void Start()
    {
        initTransform = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime);

        Vector3 move = initTransform;
        move.x += moveLenght * Mathf.Sin(Time.time * moveSpeed);
        transform.position = move;
    }
}

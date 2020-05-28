using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Balance : MonoBehaviour
{
    public float speed;
    public float angle;
    private float x;
    private Quaternion startPos;
    private Quaternion V;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.rotation;
        V = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        x += speed * Time.deltaTime;
        V = Quaternion.Euler(startPos.x, startPos.y, startPos.x + Mathf.Sin(x) * angle);
        transform.rotation = V;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeSlide : MonoBehaviour
{
    public float range;
    public float speed;
    private Vector2 startPos;
    private Vector2 V;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        V = startPos;
        V.x += range * Mathf.Sin(Time.deltaTime * speed);
        transform.position = V;
    }
}

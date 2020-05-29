using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeSlide : MonoBehaviour
{
    public float speed;
    public float range;
    private float x;
    private Vector2 startPos;
    private Vector2 V;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        V = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        x += speed * Time.deltaTime;
        V = new Vector2(startPos.x + Mathf.Sin(x) * range, startPos.y);
        transform.position = V;
    }
}

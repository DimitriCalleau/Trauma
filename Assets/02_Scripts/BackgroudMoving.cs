using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroudMoving : MonoBehaviour
{
    private float lenght;
    private float startPos;
    public GameObject camera2D;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = camera2D.transform.position.x * (1 - parallaxEffect);
        float distance = (camera2D.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        if(lenght != null)
        {
            if (temp > startPos + lenght)
            {
                startPos += lenght;
            }
            else if (temp < startPos - lenght)
            {
                startPos -= lenght;
            }
        }
    }
}

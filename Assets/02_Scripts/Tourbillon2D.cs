using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourbillon2D : MonoBehaviour
{
    public float timer;
    public float timing;

    void Update()
    {
        if(timer <= 0)
        {
            transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + 90);

            timer = timing;
        }

        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
    }
}

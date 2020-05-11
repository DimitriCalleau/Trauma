using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionPorte : MonoBehaviour
{
    public bool detected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Porte"))
        {
            detected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Porte"))
        {
            detected = false;
        }
    }
}

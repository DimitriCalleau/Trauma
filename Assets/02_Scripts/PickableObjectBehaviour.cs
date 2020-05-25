using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectBehaviour : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Tiroir"))
        {
            transform.SetParent(collision.gameObject.transform);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().useGravity = true;
    }
}

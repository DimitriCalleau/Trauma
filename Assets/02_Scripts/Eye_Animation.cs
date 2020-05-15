using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye_Animation : MonoBehaviour
{
    public Animator anm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            anm.SetBool("Detected", true);
        }
    }
}

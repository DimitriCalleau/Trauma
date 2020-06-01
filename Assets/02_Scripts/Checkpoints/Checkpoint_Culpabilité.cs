using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Culpabilité : MonoBehaviour
{
    public GameObject insultes;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            insultes.GetComponent<AffichageMotCupabilite>().FinishCulpabilite();
        }
    }
}

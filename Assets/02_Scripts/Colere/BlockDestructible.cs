using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestructible : MonoBehaviour
{
    public Sprite normal;
    public Sprite casse;
    public GameObject morceau;

    private void Awake()
    {
        if(morceau != null)
        {
            morceau.SetActive(false);
        }
        if (normal != null)
        {
            transform.GetComponent<SpriteRenderer>().sprite = normal;
        }
    }
    public void BreakingAnim()
    {
        transform.GetComponent<SpriteRenderer>().sprite = casse;
        transform.GetComponent<BoxCollider2D>().isTrigger = true;
        if (morceau != null)
        {
            morceau.SetActive(true);
        }
    }
    public void NormalDestruction()
    {
        Destroy(this.gameObject, 0.2f);
    }
}

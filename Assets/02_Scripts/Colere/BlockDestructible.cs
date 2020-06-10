using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestructible : MonoBehaviour
{
    public Sprite normal;
    public Sprite casse;

    private void Awake()
    {
        if(normal != null)
        {
            transform.GetComponent<SpriteRenderer>().sprite = normal;
        }
    }
    public void BreakingAnim()
    {
        transform.GetComponent<SpriteRenderer>().sprite = casse;
    }
    public void NormalDestruction()
    {
        Destroy(this.gameObject, 0.2f);
    }
}

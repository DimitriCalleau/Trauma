using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestructible : MonoBehaviour
{
    public void BreakingAnim()
    {
        Destroy(this.gameObject, 0.2f);
    }
    public void NormalDestruction()
    {
        Destroy(this.gameObject, 0.2f);
    }
}

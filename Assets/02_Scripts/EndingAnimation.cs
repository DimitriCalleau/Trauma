using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAnimation : MonoBehaviour
{
    public GameObject player;

    public void FinishEndingAnimation()
    {
        player.GetComponent<Controller2D>().FinishLevel();
    }
}

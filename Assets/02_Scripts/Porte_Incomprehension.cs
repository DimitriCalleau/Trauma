using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte_Incomprehension : MonoBehaviour
{
    public GameObject dragon;
    public void FinishIncomprehension()
    {
        dragon.GetComponent<Controller2D>().FinishLevel();
    }
}

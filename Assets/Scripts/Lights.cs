using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject windowLight;

    public void ActivateObject()
    {
        Debug.Log("Let there be light");
        windowLight.SetActive(true);
    }

}

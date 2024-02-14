using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGarden : MonoBehaviour
{
    public GameObject windowExit;

    public void ActivateObject()
    {
        Debug.Log("Garden is active");
        windowExit.SetActive(true);
    }

}

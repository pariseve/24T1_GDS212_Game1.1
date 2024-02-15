using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    // use this script to spawn in the paper ball when the bin falls over
    public GameObject objToSpawn;
    private bool hasSpawned = false;

    public void SpawnObjectOnce()
    {
        if (!hasSpawned)
        {
            Instantiate(objToSpawn, transform.position, transform.rotation);
            Debug.Log("Object spawned");
        }
        else
        {
            Debug.Log("Object has already spawned");
        }
    }
}

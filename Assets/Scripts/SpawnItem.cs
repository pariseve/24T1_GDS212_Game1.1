using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    // Use this script to spawn in the paper ball when the bin falls over
    public GameObject objToSpawn;
    private bool hasSpawned = false;

    private Collider2D spawnCollider;

    private void Start()
    {
        // Get the collider component attached to this GameObject
        spawnCollider = GetComponent<Collider2D>();
    }

    public void SpawnObjectOnce()
    {
        if (!hasSpawned)
        {
            Instantiate(objToSpawn, transform.position, transform.rotation);
            Debug.Log("Object spawned");
            hasSpawned = true; // Set the flag to true after spawning

            // Disable the collider to prevent further interactions
            spawnCollider.enabled = false;
        }
        else
        {
            Debug.Log("Object has already spawned");
        }
    }
}


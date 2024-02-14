using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteChangeOnInteraction : MonoBehaviour
{
    public TaskManager taskManager;

    public Sprite newSprite; // The new sprite to be set

    [SerializeField] private UnityEvent function;

    private SpriteRenderer spriteRenderer;

    private bool playerInArea = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player entered the trigger area
        if (collision.CompareTag("Player"))
        {
            // Provide feedback to the player if needed
            Debug.Log("Press F to change sprite");
            playerInArea = true;
            StartCoroutine(CheckForKeyPress());
        }
    }
    
    private IEnumerator CheckForKeyPress()
    {
        while (playerInArea)
        {
            Debug.Log("Player in area");
            // Check for interaction input
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Player hit key in area");
                // Change the sprite
                ChangeSprite();
            }
            yield return null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the player exited the trigger area
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player left area");
            playerInArea = false;
        }
    }

    private void ChangeSprite()
    {
        // Check if a new sprite is assigned
        if (newSprite != null)
        {
            Debug.Log("sprite changed");
            // Change the sprite
            spriteRenderer.sprite = newSprite;
            if(function != null)
            {
                function.Invoke();
            }
        }
        else
        {
            Debug.LogWarning("New sprite is not assigned!");
        }
    }
}

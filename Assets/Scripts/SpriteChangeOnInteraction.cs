using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteChangeOnInteraction : MonoBehaviour
{
    public TaskManager taskManager;
    public string taskId;

    public Sprite newSprite; //new sprite to replace old one

    [SerializeField] private UnityEvent function;
    [SerializeField] private UnityEvent<string> checkFunction;

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
            Debug.Log("Sprite changed");
            // Change the sprite
            spriteRenderer.sprite = newSprite;

            // Find the task associated with the sprite change
            Task task = taskManager.tasks.Find(t => t.id == taskId);

            // Check if the task exists
            if (task != null)
            {
                // Check if the task associated with the sprite change is complete
                if (task.IsComplete)
                {
                    Debug.Log("Task is already complete!");
                }
                else
                {
                    Debug.Log("Task is now complete!");
                    // Set the task associated with the sprite change as complete
                    taskManager.SetTaskComplete(taskId);
                }
            }
            else
            {
                Debug.LogWarning("Task not found!");
            }

            // Invoke the Unity Event if assigned
            if (checkFunction != null)
            {
                checkFunction.Invoke(taskId);
            }
            else
            {
                Debug.LogWarning("Check Function Unity Event is not assigned!");
            }
        }
        else
        {
            Debug.LogWarning("New sprite is not assigned!");
        }
    }
}


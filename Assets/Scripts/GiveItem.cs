using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GiveItem : MonoBehaviour
{
    public TaskManager taskManager;
    public string taskId;

    public Sprite newSprite; //new sprite to replace old one

    [SerializeField] private UnityEvent<string> checkFunction;

    public string customTag; // Custom tag for the trigger area

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player entered the trigger area with the specified custom tag
        if (collision.CompareTag(customTag))
        {
            // Provide feedback to the player if needed
            Debug.Log("Player is in trigger area with the specified tag");
            ChangeSprite();
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

            // Destroy the game object with the specified tag
            GameObject objectToDestroy = GameObject.FindGameObjectWithTag(customTag);
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
            }
            else
            {
                Debug.LogWarning("No game object found with the specified tag to destroy!");
            }
        }
        else
        {
            Debug.LogWarning("New sprite is not assigned!");
        }
    }
}

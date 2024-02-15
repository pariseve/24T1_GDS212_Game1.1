using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string horizontalInputAxis = "Horizontal";
    public string verticalInputAxis = "Vertical";

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public Sprite jumpingSprite;
    public Sprite reachUpSprite;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded = false; // Track the grounded state

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis(horizontalInputAxis);

        // Move the player horizontally
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Trigger movement animation
        if (horizontalInput != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        // Flip the character based on the input direction
        FlipCharacter(horizontalInput);

        // Check for jump input (spacebar or W key) and grounded state
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            animator.enabled = false;
            Debug.Log("Jumping...");
            // Swap sprite to jumping sprite
            if (jumpingSprite != null)
            {
                Debug.Log("Applying jumping sprite");
                spriteRenderer.sprite = jumpingSprite;
                spriteRenderer.transform.localScale = new Vector3(0.2f, 0.2f, 1f); // Scale down to 0.4
            }
            else
            {
                Debug.LogWarning("Jumping sprite is not assigned!");
            }

            // Ensure the velocity is zero before applying the impulse
            rb.velocity = Vector2.zero;

            // Apply a vertical impulse to simulate a jump
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            isGrounded = false; // Set grounded state to false
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true; // Set grounded state to true when colliding with ground
            animator.enabled = true;
            spriteRenderer.transform.localScale = new Vector3(0.4f, 0.4f, 1f);

            // Swap sprite back to regular sprite
            // Assuming you have a reference to the regular sprite
            //spriteRenderer.sprite = regularSprite;
        }
    }

    private void FlipCharacter(float horizontalInput)
    {
        // Flip the character sprite based on the input direction
        if (horizontalInput < 0)
        {
            // If moving left, keep the character facing right
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            // If moving right, flip the character to face left
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // If horizontalInput is 0, maintain the current facing direction
    }

    public void ReachingPose()
    {
        animator.enabled = false;
        if (reachUpSprite != null)
        {
            Debug.Log("Applying reaching up sprite");
            spriteRenderer.sprite = reachUpSprite;
            spriteRenderer.transform.localScale = new Vector3(0.2f, 0.2f, 1f); // Scale down to 0.4

            // Start a coroutine to enable the animator after 2 seconds
            StartCoroutine(EnableAnimatorAfterDelay(0.5f));
        }
        else
        {
            Debug.LogWarning("Jumping sprite is not assigned!");
        }
    }

    private IEnumerator EnableAnimatorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.enabled = true;
        spriteRenderer.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
    }

}

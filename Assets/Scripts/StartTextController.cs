using UnityEngine;

public class StartTextController : MonoBehaviour
{
    [SerializeField] private Canvas startTextCanvas;

    private void Start()
    {
        // Ensure the canvas is initially enabled
        if (startTextCanvas != null)
        {
            startTextCanvas.enabled = true;
        }
    }

    private void Update()
    {
        // Check for space key input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Disable the canvas when space key is pressed
            if (startTextCanvas != null)
            {
                startTextCanvas.enabled = false;
            }
        }
    }
}

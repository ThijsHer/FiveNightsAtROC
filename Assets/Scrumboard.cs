using UnityEngine;
using UnityEngine.UI;

public class Scrumboard : MonoBehaviour
{
    public GameObject objectToToggleAndMove; // Reference to the object you want to toggle visibility and move
    private bool isVisible = false;
    private bool isMovingUp = false;

    public float moveSpeed = 5.0f; // Adjust the speed as needed
    public float moveDistance = 2.0f; // Adjust the distance as needed

    void Start()
    {
        Button button = GetComponent<Button>();

        // Make sure to attach a button component to the GameObject
        if (button != null)
        {
            // Subscribe to the button click event
            button.onClick.AddListener(ToggleVisibilityAndMovement);
        }
        else
        {
            Debug.LogError("Button component not found on GameObject: " + gameObject.name);
        }
    }

    void Update()
    {
        if (isMovingUp)
        {
            // Move the object upward
            objectToToggleAndMove.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // Check if the object has reached the desired distance
            if (objectToToggleAndMove.transform.position.y >= moveDistance)
            {
                isMovingUp = false;
            }
        }
    }

    void ToggleVisibilityAndMovement()
    {
        isVisible = !isVisible;
        isMovingUp = !isMovingUp;

        // Set the object's visibility
        objectToToggleAndMove.SetActive(isVisible);
    }
}


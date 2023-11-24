using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLeftRight : MonoBehaviour
{
    public float startX = -5f; // Starting X position
    public float endX = 5f;    // Ending X position
    public float duration = 4.0f; // Time taken to move from left to right

    private float timer = 0.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;

    void Start()
    {
        startPosition = new Vector3(startX, transform.position.y, transform.position.z);
        endPosition = new Vector3(endX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration); // Calculate the interpolation parameter

        // Use Mathf.Lerp to move the camera smoothly from left to right along the X-axis
        transform.position = Vector3.Lerp(startPosition, endPosition, t);

        // Reset the timer when it reaches the duration to loop the movement
        if (timer >= duration)
        {
            timer = 0.0f;
            // Swap start and end positions for continuous movement
            Vector3 temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
        }
    }
}

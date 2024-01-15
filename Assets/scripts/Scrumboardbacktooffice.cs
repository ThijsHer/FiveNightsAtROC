using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Scrumboardbacktooffice : MonoBehaviour
{
    public RectTransform objectToMoveAndDisappear; // Reference to the object you want to move and disappear
    private bool isMovingDown = false;

    public float moveSpeed = 5.0f; // Adjust the speed as needed

    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private Button openButton;

    public float newY;

    void Start()
    {

        // Make sure to attach a button component to the GameObject
        if(openButton)
        openButton.onClick.AddListener(() => { ToggleCanvas(true); });
        if (closeButton)
            closeButton.onClick.AddListener(() => { ToggleCanvas(false); });
    }

    private void OnDestroy()
    {
        if(openButton)
        openButton.onClick.RemoveAllListeners();
        if(closeButton)
        closeButton.onClick.RemoveAllListeners();
    }

    private void ToggleCanvas(bool shouldOpen)
    {
        StartCoroutine(ToggleCanvasRoutine(shouldOpen));
        Debug.Log($"reeeee {shouldOpen}");
    }

    private IEnumerator ToggleCanvasRoutine(bool shouldOpen)
    {
        float targetY = shouldOpen ? 0 : -1080; // Set the target Y position based on whether it should open or close
        float elapsedTime = 0f;

        // Disable the button during the animation
        closeButton.enabled = false;

        Vector2 startPosition = objectToMoveAndDisappear.anchoredPosition;
        Vector2 targetPosition = new Vector2(startPosition.x, targetY);

        while (elapsedTime < moveSpeed)
        {
            objectToMoveAndDisappear.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is set to the target position
        objectToMoveAndDisappear.anchoredPosition = targetPosition;

        // Enable the button after the animation
        closeButton.enabled = true;
    }
}
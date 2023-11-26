using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float flashlightSize = 100f; // Size of the flashlight effect

    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        rectTransform.position = mousePos;

        rectTransform.sizeDelta = new Vector2(flashlightSize, flashlightSize);
    }
}

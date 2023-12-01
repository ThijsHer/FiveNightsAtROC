using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Textflicker : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Color flickerColor = Color.green;
    public float flickerSpeed = 0.5f;

    private Color originalColor;
    private bool isFlickering = false;

    private void Start()
    {
        originalColor = textMeshPro.color;
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            if (!isFlickering)
            {
                isFlickering = true;
                textMeshPro.color = flickerColor;
            }
            else
            {
                isFlickering = false;
                textMeshPro.color = originalColor;
            }

            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}

using System.Collections;
using TMPro;
using UnityEngine;

public class fadein : MonoBehaviour
{
    public float delayBeforeFade = 2f; // Delay before starting the fade-in effect
    public float fadeInDuration = 1.5f; // Duration of the fade-in effect in seconds

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        // Set the initial alpha to 0 (fully transparent)
        Color textColor = textMesh.color;
        textColor.a = 0f;
        textMesh.color = textColor;

        // Start the delay before the fade-in effect
        StartCoroutine(StartFadeInAfterDelay());
    }

    private IEnumerator StartFadeInAfterDelay()
    {
        // Wait for the specified delay before starting the fade-in effect
        yield return new WaitForSeconds(delayBeforeFade);

        float elapsedTime = 0f;
        Color textColor = textMesh.color;

        // Gradually increase the alpha value to make the text visible (fade-in effect)
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            textColor.a = alpha;
            textMesh.color = textColor;
            yield return null;
        }

        // Ensure the text is fully visible by setting the alpha to 1 (fully opaque)
        textColor.a = 1f;
        textMesh.color = textColor;
    }
}

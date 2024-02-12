using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VikingAI : MonoBehaviour
{
    private string currentLocation;

    public int aiLevel;
    public GameObject jumpscareObject;
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;
    public GameObject stage5;
    public GameObject snowballStage1;
    public GameObject snowballStage2;
    public GameObject snowballStage3;
    public GameObject snowballStage4;
    public GameObject snowballSplatterStage1;
    public GameObject snowballSplatterStage2;
    public GameObject snowballSplatterStage3;
    public GameObject snowballSplatterStage4;
    public float throwDuration = 1.5f;
    public float splatterDuration = 12f;

    public Canvas doorUI;
    public GameObject doorCam;
    public Button backToOfficeButton;
    public AudioSource jumpscareSound;

    void Start()
    {
        currentLocation = "stage1";
        StartCoroutine(VikingMove());
    }

    IEnumerator VikingMove()
    {
        yield return new WaitForSeconds(5f);

        int chance = Random.Range(1, 21);

        if (chance <= aiLevel)
        {
            if (currentLocation == "stage1")
            {
                StartCoroutine(ThrowSnowball(snowballStage1, snowballSplatterStage1));
                stage1.SetActive(false);
                currentLocation = "stage2";
                stage2.SetActive(true);
            }
            else if (currentLocation == "stage2")
            {
                StartCoroutine(ThrowSnowball(snowballStage2, snowballSplatterStage2));
                stage2.SetActive(false);
                currentLocation = "stage3";
                stage3.SetActive(true);
            }
            else if (currentLocation == "stage3")
            {
                StartCoroutine(ThrowSnowball(snowballStage3, snowballSplatterStage3));
                stage3.SetActive(false);
                currentLocation = "stage4";
                stage4.SetActive(true);
            }
            else if (currentLocation == "stage4")
            {
                StartCoroutine(ThrowSnowball(snowballStage4, snowballSplatterStage4));
                stage4.SetActive(false);
                currentLocation = "stage5";
                stage5.SetActive(true);
            }
            if (currentLocation == "stage5")
            {
                yield return new WaitForSeconds(8f);
                if (doorCam.activeSelf && !backToOfficeButton.IsActive())
                {
                    // Handle if door cam is active and back to office button is not active
                }
                else
                {
                    jumpscareSound.Play();
                    yield return new WaitForSeconds(1f);
                    // Load the next scene
                    SceneManager.LoadScene("GameOver");
                }
            }
            StartCoroutine(VikingMove());
        }
    }

    IEnumerator ThrowSnowball(GameObject snowball, GameObject splatter)
    {
        snowball.SetActive(true); // Activate the snowball
        Vector3 originalScale = snowball.transform.localScale; // Save the original scale
        float elapsedTime = 0f;

        while (elapsedTime < throwDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / throwDuration;
            snowball.transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t); // Animate from small to original scale
            yield return null;
        }

        snowball.SetActive(false); // Deactivate the snowball after the throw animation completes

        // Activate snowball splatter
        splatter.SetActive(true);
        // Start coroutine to deactivate snowball splatter after specified duration
        StartCoroutine(DeactivateSplatterEffect(splatter, splatterDuration));
    }

    IEnumerator DeactivateSplatterEffect(GameObject splatter, float duration)
    {
        yield return new WaitForSeconds(duration);
        splatter.SetActive(false);
    }
}

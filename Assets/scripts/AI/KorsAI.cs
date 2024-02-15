using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KorsAI : MonoBehaviour
{
    public GameObject tvDisplay; // GameObject representing the TV display
    public GameObject jumpscareObject; // GameObject for the jumpscare
    public Button hideButton;
    public AudioSource jumpscareaudio;
    public AudioSource dislayyaudio;
    public Canvas deurui;
    public GameObject camerahandler;

    private bool isWaitingForInput = false;
    private bool isJumpscareTriggered = false; // Flag to track if jumpscare is triggered
    private Coroutine displayCoroutine;

    // Define different ranges for display and jumpscare times based on AI levels
    private float[] minDisplayTimes = { 180f, 45f, 20f, 15f, 10f, 70f }; // Min display time for each level
    private float[] maxDisplayTimes = { 180f, 60f, 40f, 30f, 20f, 70 }; // Max display time for each level
    private float[] timeBeforeJumpScares = { 10f, 10f, 10f, 10f, 10f, 10f }; // Time before jumpscare for each level

    // Current AI level (for example, set it externally based on the game progress)
    public int currentAILevel;

    void Start()
    {
        tvDisplay.SetActive(false); // Initially hide the TV display
        jumpscareObject.SetActive(false); // Initially hide the jumpscare object
        displayCoroutine = StartCoroutine(ShowTVDisplay());
    }

    IEnumerator ShowTVDisplay()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            float displayTime = Random.Range(minDisplayTimes[currentAILevel - 1], maxDisplayTimes[currentAILevel - 1]);
            Debug.Log("Display Time: " + displayTime + " seconds");

            yield return new WaitForSeconds(displayTime);

            tvDisplay.SetActive(true);
            AudioSource displayAudio = tvDisplay.GetComponent<AudioSource>();

            if (displayAudio != null)
            {
                displayAudio.Play();
            }
            else
            {
                Debug.LogError("No AudioSource component found in the tvDisplay GameObject.");
            }

            float timer = 0f;

            while (timer < timeBeforeJumpScares[currentAILevel - 1])
            {
                timer += Time.deltaTime;

                if (isWaitingForInput)
                {
                    isWaitingForInput = false;
                    tvDisplay.SetActive(false);
                    Debug.Log("Button clicked, TV Hiding...");
                    yield return new WaitForSeconds(1f);
                    break;
                }

                yield return null;
            }

            if (timer >= timeBeforeJumpScares[currentAILevel - 1] && !isJumpscareTriggered)
            {
                camerahandler.GetComponent<Cameras>().SwitchToCamDown(true);
                camerahandler.GetComponent<Cameras>().BackToTheOffice(true);
                isJumpscareTriggered = true;
                jumpscareObject.SetActive(true);
                tvDisplay.SetActive(false);

                jumpscareaudio = jumpscareObject.GetComponent<AudioSource>();

                if (jumpscareaudio != null)
                {
                    jumpscareaudio.Play();
                }
                else
                {
                    Debug.LogError("No AudioSource component found in the jumpscareObject.");
                }

                Debug.Log("Jumpscare triggered, TV Hiding...");
                yield return new WaitForSeconds(4f);

                SceneManager.LoadScene("GameOver");
                break;
            }
        }
    }

    public void OnHideButtonClick()
    {
        if (tvDisplay.activeSelf)
        {
            isWaitingForInput = true;
            tvDisplay.SetActive(false);
            Debug.Log("Button clicked.");
        }
        else
        {
            Debug.Log("Button clicked, but TV is hidden.");
        }
    }
}

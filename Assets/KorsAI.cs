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
    public float minDisplayTime = 5f; // Minimum time for TV display
    public float maxDisplayTime = 10f; // Maximum time for TV display
    public float timeToClickButton = 3f; // Time to click the button before a jumpscare
    public float timeBeforeJumpscare = 8f; // Time before the jumpscare triggers
    public AudioSource jumpscareaudio;
    public AudioSource dislayyaudio;

    private bool isWaitingForInput = false;
    private bool isJumpscareTriggered = false; // Flag to track if jumpscare is triggered
    private Coroutine displayCoroutine;

    void Start()
    {
        tvDisplay.SetActive(false); // Initially hide the TV display
        jumpscareObject.SetActive(false); // Initially hide the jumpscare object
        displayCoroutine = StartCoroutine(ShowTVDisplay());
    }

    IEnumerator ShowTVDisplay()
    {
        while (true)
        {
            float displayTime = Random.Range(minDisplayTime, maxDisplayTime);
            Debug.Log("Display Time: " + displayTime + " seconds");

            yield return new WaitForSeconds(displayTime);

            tvDisplay.SetActive(true);

            // Get the AudioSource component from the tvDisplay GameObject
            AudioSource displayAudio = tvDisplay.GetComponent<AudioSource>();

            // Check if the AudioSource component exists and play the audio
            if (displayAudio != null)
            {
                displayAudio.Play();
            }
            else
            {
                Debug.LogError("No AudioSource component found in the tvDisplay GameObject.");
            }

            float timer = 0f;

            while (timer < timeBeforeJumpscare)
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

            if (timer >= timeBeforeJumpscare && !isJumpscareTriggered)
            {
                isJumpscareTriggered = true;
                jumpscareObject.SetActive(true);
                tvDisplay.SetActive(false);

                // Get the AudioSource component from the jumpscareObject
                jumpscareaudio = jumpscareObject.GetComponent<AudioSource>();

                // Ensure there is an AudioSource component
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
            }

            if (isJumpscareTriggered)
            {
                SceneManager.LoadScene("GameOver");
                break;
            }
        }
    }

    public void OnHideButtonClick()
    {
        isWaitingForInput = true;
        tvDisplay.SetActive(false);
        Debug.Log("Button clicked.");
    }
}

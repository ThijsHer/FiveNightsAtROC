using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Night2Time : MonoBehaviour
{
    public float gameDurationInSeconds = 60; // Total game duration in seconds
    public float timeScale = 1.0f; // Adjustable speed of the timer
    public GameObject textObject; // Reference to the GameObject containing TextMeshPro

    private TextMeshProUGUI timerText;
    private float currentTime;
    private int currentHour = 0; // Track the current in-game hour
    private bool gameEnded = false;

    public RICK rickAI;
    public KorsAI korsAI;
    public PaulAI PaulAI;
    public PeterAI PeterAI;

    void Start()
    {
        currentTime = gameDurationInSeconds; // Start time set to the game duration

        // Get the TextMeshPro component from the GameObject
        timerText = textObject.GetComponent<TextMeshProUGUI>();
        if (timerText == null)
        {
            Debug.LogError("No TextMeshProUGUI component found on the provided GameObject.");
        }
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!gameEnded)
        {
            currentTime -= Time.deltaTime * timeScale;

            if (currentTime <= 0)
            {
                EndGame();
            }
            else
            {
                UpdateTimerDisplay();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        float hoursPassed = (gameDurationInSeconds - currentTime) / (gameDurationInSeconds / 6); // Calculate hours passed
        currentHour = Mathf.FloorToInt(hoursPassed);
        string timeString = string.Format("{0} AM", (currentHour == 0) ? "12" : currentHour.ToString());

        // Update the UI Text element
        timerText.text = "" + timeString;

        if (currentHour == 0)
        {
            rickAI.ailevel = 1;
            korsAI.currentAILevel = 1;
            PaulAI.ailevel = 1;
            PeterAI.ailevel = 0;
        }
        else if (currentHour == 1)
        {
            rickAI.ailevel = 2;
            korsAI.currentAILevel = 2;
            PaulAI.ailevel = 2;
            PeterAI.ailevel= 2;
        }
        else if(currentHour == 2)
        {
            rickAI.ailevel = 2;
            korsAI.currentAILevel = 2;
            PaulAI.ailevel = 2;
            PeterAI.ailevel = 2;
        }
        else if (currentHour == 3)
        {
            rickAI.ailevel = 4;
            korsAI.currentAILevel = 2;
            PaulAI.ailevel = 2;
            PeterAI.ailevel = 3;
        }
        else if (currentHour == 4)
        {
            rickAI.ailevel = 4;
            korsAI.currentAILevel = 2;
            PaulAI.ailevel = 3;
            PeterAI.ailevel = 3;
        }
        else if (currentHour == 5)
        {
            rickAI.ailevel = 6;
            korsAI.currentAILevel = 2;
            PaulAI.ailevel = 3;
            PeterAI.ailevel = 4;
        }
    }

    void EndGame()
    {
        PlayerPrefs.SetString("currentnight", "Night 3");
        gameEnded = true;
        timerText.text = "6 AM";
        SceneManager.LoadScene("6AM");
    }

    public void SetTimeScale(float newTimeScale)
    {
        timeScale = newTimeScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class secretcode : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentIndex = 0;
    private KeyCode[] requiredKeys = { KeyCode.Alpha6, KeyCode.Alpha9, KeyCode.Alpha4, KeyCode.Alpha2, KeyCode.Alpha0 };
    void Update()
    {
        if (Input.anyKeyDown)
        {
            // Check if the player presses the correct key in order
            if (Input.GetKeyDown(requiredKeys[currentIndex]))
            {
                currentIndex++;

                // Check if the entire sequence has been entered
                if (currentIndex == requiredKeys.Length)
                {
                    // Call a method to change the scene
                    ChangeScene();
                    // Reset the index for the next sequence
                    currentIndex = 0;
                }
            }
            else
            {
                // Reset the index if the wrong key is pressed
                currentIndex = 0;
            }
        }
    }

    void ChangeScene()
    {
        Debug.Log("Changing scene to 'secretnight'");
        // Replace "secretnight" with the actual name of your target scene
        SceneManager.LoadScene("secretam");
    }
}
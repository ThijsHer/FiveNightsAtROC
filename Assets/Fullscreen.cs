using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        // Check if the "F" key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Toggle fullscreen mode
            ToggleFullscreen();
        }
    }

    // Call this method to toggle fullscreen mode
    public void ToggleFullscreen()
    {
        // Toggle between fullscreen and windowed mode
        Screen.fullScreen = !Screen.fullScreen;
    }

    // Call this method to exit fullscreen mode explicitly
    public void ExitFullscreen()
    {
        // Set fullscreen to false to exit fullscreen mode
        Screen.fullScreen = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoflicker : MonoBehaviour
{
    public float flickerInterval = 0.5f; // Interval for flickering (in seconds)

    private GameObject flickerObject;
    private bool isFlickering = false;

    void Start()
    {
        //flickerObject = gameObject; // Reference to the GameObject this script is attached to
        //InvokeRepeating("ToggleVisibility", flickerInterval, flickerInterval);
    }

    public void start()
    {
        flickerObject = gameObject;
        InvokeRepeating("ToggleVisibility", flickerInterval, flickerInterval);
    }
    public void stop()
    {
        CancelInvoke("ToggleVisibility");
    }
    public void ToggleVisibility()
    {
        isFlickering = !isFlickering;
        flickerObject.SetActive(isFlickering);
    }
}

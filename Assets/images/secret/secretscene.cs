using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class secretam : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay());
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(10f); // Wait for 5 seconds
        SceneManager.LoadScene("secretnight"); // Replace "YourSceneName" with the name of the scene you want to load
    }
}
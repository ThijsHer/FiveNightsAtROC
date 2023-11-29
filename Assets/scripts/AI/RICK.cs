using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RICK : MonoBehaviour
{
    public GameObject rickcam7;
    public GameObject rickcam6;
    public GameObject rickcam5;
    public GameObject rickcam4;
    public GameObject rickcam3;
    public GameObject rickcam1;
    public GameObject rickoffice;
    public GameObject camerahandler;
    public AudioSource rickjumpscaresound;
    private string currentlocation;
    public int ailevel;

    public AudioSource RickWegVanDeur;
    public Canvas deurui;
    public GameObject doorcam;
    public Button backtoofficebutton;

    void Start()
    {
        currentlocation = "cam7";
        StartCoroutine(rickMovement());
    }

    // Update is called once per frame
    IEnumerator rickMovement()
    {
        yield return new WaitForSeconds(5f);

        int chance = UnityEngine.Random.Range(1, 21);
        Debug.Log(chance);

        if (chance <= ailevel)
        {
            if (currentlocation == "cam7")
            {
                rickcam7.gameObject.SetActive(false);
                currentlocation = "cam6";
                rickcam6.gameObject.SetActive(true);
            }
            else if (currentlocation == "cam6")
            {
                rickcam6.gameObject.SetActive(false);
                currentlocation = "cam5";
                rickcam5.gameObject.SetActive(true);
            }
            else if (currentlocation == "cam5")
            {
                rickcam5.gameObject.SetActive(false);
                currentlocation = "cam4";
                rickcam4.gameObject.SetActive(true);
            }
            else if (currentlocation == "cam4")
            {
                rickcam4.gameObject.SetActive(false);
                currentlocation = "cam3";
                rickcam3.gameObject.SetActive(true);
            }
            else if (currentlocation == "cam3")
            {
                rickcam3.gameObject.SetActive(false);
                currentlocation = "cam1";
                rickcam1.gameObject.SetActive(true);
            }
            
        }
        if (currentlocation == "cam1")
        {
            yield return new WaitForSeconds(8f);
            if (doorcam.activeSelf && !(backtoofficebutton.IsActive()))
            {
                rickcam1.gameObject.SetActive(false);
                currentlocation = "cam7";
                rickcam7.gameObject.SetActive(true);
                RickWegVanDeur.Play();
            }
            else
            {
                rickcam1.gameObject.SetActive(false);
                currentlocation = "office";
                rickoffice.gameObject.SetActive(true);
                deurui.gameObject.SetActive(false);
                camerahandler.GetComponent<Cameras>().SwitchToCamDown();
                rickjumpscaresound.Play();

                // Wait for a few seconds after the jumpscare before changing the scene
                yield return new WaitForSeconds(3f); // Change 3f to your desired delay

                // Load the next scene
                SceneManager.LoadScene("GameOver"); // Replace "YourNextScene" with your scene name
            }

        }
        StartCoroutine(rickMovement());
    }
}

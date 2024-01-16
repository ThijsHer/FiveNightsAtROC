using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lethalcompany : MonoBehaviour
{
    public GameObject rickcam7;
    public GameObject rickcam6;
    public GameObject rickcam5;
    public GameObject rickcam4;
    public GameObject rickcam3;
    public GameObject rickcam1;

    public GameObject staticcam7;
    public GameObject staticcam6;
    public GameObject staticcam5;
    public GameObject staticcam4;
    public GameObject staticcam3;
    public GameObject staticcam1;

    public GameObject rickoffice;
    public GameObject camerahandler;
    private string currentlocation;
    public int ailevel;


    public GameObject shitdatindewegzit;

    public AudioSource RickWegVanDeur;
    public Canvas deurui;
    public GameObject doorcam;
    public Button backtoofficebutton;

    public AudioSource[] audioClips;
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
                staticcam7.SetActive(true);
                staticcam6.SetActive(true);
                rickcam7.gameObject.SetActive(false);
                currentlocation = "cam6";
                rickcam6.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam7.SetActive(false);
                staticcam6.SetActive(false);
            }
            else if (currentlocation == "cam6")
            {
                staticcam5.SetActive(true);
                staticcam6.SetActive(true);
                rickcam6.gameObject.SetActive(false);
                currentlocation = "cam5";
                rickcam5.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam5.SetActive(false);
                staticcam6.SetActive(false);
            }
            else if (currentlocation == "cam5")
            {
                staticcam5.SetActive(true);
                staticcam4.SetActive(true);
                rickcam5.gameObject.SetActive(false);
                currentlocation = "cam4";
                rickcam4.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam5.SetActive(false);
                staticcam4.SetActive(false);
            }
            else if (currentlocation == "cam4")
            {
                staticcam4.SetActive(true);
                staticcam3.SetActive(true);
                rickcam4.gameObject.SetActive(false);
                currentlocation = "cam3";
                rickcam3.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam4.SetActive(false);
                staticcam3.SetActive(false);
            }
            else if (currentlocation == "cam3")
            {
                staticcam3.SetActive(true);
                staticcam1.SetActive(true);
                rickcam3.gameObject.SetActive(false);
                currentlocation = "cam1";
                rickcam1.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam3.SetActive(false);
                staticcam1.SetActive(false);
            }
            
        }
        if (currentlocation == "cam1")
        {
            yield return new WaitForSeconds(8f);
            if (doorcam.activeSelf && !(backtoofficebutton.IsActive()))
            {
                staticcam7.SetActive(true);
                staticcam1.SetActive(true);
                rickcam1.gameObject.SetActive(false);
                currentlocation = "cam7";
                rickcam7.gameObject.SetActive(true);

                // Randomly select an audio clip
                int randomIndex = UnityEngine.Random.Range(0, audioClips.Length);
                AudioSource selectedAudio = audioClips[randomIndex];

                // Play the selected audio clip
                selectedAudio.Play();
                RickWegVanDeur.Play();

                yield return new WaitForSeconds(0.1f);
                staticcam7.SetActive(false);
                staticcam1.SetActive(false);
            }
            // Your existing code...

            else
            {
                // Pause other activities
                Time.timeScale = 0f;

                rickcam1.gameObject.SetActive(false);
                shitdatindewegzit.SetActive(false);
                currentlocation = "office";
                rickoffice.gameObject.SetActive(true);
                camerahandler.GetComponent<Cameras>().SwitchToCamDown(true);
                camerahandler.GetComponent<Cameras>().BackToTheOffice(true);
                rickoffice.gameObject.GetComponent<animplayer>().Func_PlayUIAnim();

                yield return new WaitForSecondsRealtime(18f);
                // Use WaitForSecondsRealtime to ignore Time.timeScale

                // Resume other activities
                Time.timeScale = 1f;

                // Load the next scene
                SceneManager.LoadScene("GameOver"); // Replace "YourNextScene" with your scene name
            }


        }
        StartCoroutine(rickMovement());
    }
}

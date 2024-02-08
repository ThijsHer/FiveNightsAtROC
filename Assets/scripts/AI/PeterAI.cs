using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PeterAI : MonoBehaviour
{
    private string currentlocation;

    public int ailevel;

    private int hallwindow;

    public GameObject peterROCITstage1;
    public GameObject peterROCITstage2;
    public GameObject peterROCITstage3;
    public GameObject peterROCITstage3V2;
    public GameObject petercam3;
    public GameObject petercam1;

    public GameObject officepeter;
    public GameObject officeraam;
    public AudioSource breakraam;

    public GameObject rocitstatic;
    public GameObject cam3static;
    public GameObject cam1static;

    public GameObject shitdatindewegzit;

    public AudioSource PeterWegVanDeur;
    public Canvas deurui;
    public GameObject doorcam;
    public Button backtoofficebutton;
    public GameObject camerahandler;
    public AudioSource Peterjumpscaresound;

    public AudioSource[] audioClips;

    public GameObject buttonunpressed;
    public GameObject buttonpressed;
    public GameObject spike;


    public AudioSource pressbuttonsound;
    public AudioSource shanksound;
    public AudioSource wallsound;

    void Start()
    {
        currentlocation = "stage1";
        StartCoroutine(peterMover());
    }

    public void pressbutton()
    {
        StartCoroutine(peterbutton());
    }

    IEnumerator peterMover()
    {
        yield return new WaitForSeconds(5f);

        int chance = UnityEngine.Random.Range(1, 21);

        if (chance <= ailevel)
        {
            if (currentlocation == "stage1")
            {
                rocitstatic.SetActive(true);
                peterROCITstage1.gameObject.SetActive(false);
                currentlocation = "stage2";
                peterROCITstage2.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                rocitstatic.SetActive(false);
            }
            else if (currentlocation == "stage2")
            {
                hallwindow = UnityEngine.Random.Range(1, 3);
                rocitstatic.SetActive(true);
                peterROCITstage2.gameObject.SetActive(false);
                currentlocation = "stage3";
                if (hallwindow == 1)
                {
                    peterROCITstage3V2.gameObject.SetActive(true);
                }
                else
                {
                    peterROCITstage3.gameObject.SetActive(true);
                }
                yield return new WaitForSeconds(0.1f);
                rocitstatic.SetActive(false);
            }
            else if (currentlocation == "stage3")
            {
                if (hallwindow == 1)
                {
                    rocitstatic.SetActive(true);
                    peterROCITstage3V2.gameObject.SetActive(false);
                    currentlocation = "buiten";
                    yield return new WaitForSeconds(0.1f);
                    rocitstatic.SetActive(false);
                }
                else
                {
                    rocitstatic.SetActive(true);
                    cam3static.SetActive(true);
                    peterROCITstage3.gameObject.SetActive(false);
                    currentlocation = "cam3";
                    petercam3.gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                    rocitstatic.SetActive(false);
                    cam3static.SetActive(false);
                }

            }
            else if (currentlocation == "cam3")
            {
                cam3static.SetActive(true);
                cam1static.SetActive(true);
                petercam3.gameObject.SetActive(false);
                currentlocation = "cam1";
                petercam1.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                cam1static.SetActive(false);
                cam3static.SetActive(false);
            }
        }
        if (currentlocation == "cam1")
        {
            yield return new WaitForSeconds(8f);
            if (doorcam.activeSelf && !(backtoofficebutton.IsActive()))
            {
                rocitstatic.SetActive(true);
                cam1static.SetActive(true);
                petercam1.gameObject.SetActive(false);
                currentlocation = "stage1";
                peterROCITstage1.gameObject.SetActive(true);

                int randomIndex = UnityEngine.Random.Range(0, audioClips.Length);
                AudioSource selectedAudio = audioClips[randomIndex];

                // Play the selected audio clip
                selectedAudio.Play();
                PeterWegVanDeur.Play();

                yield return new WaitForSeconds(0.1f);
                rocitstatic.SetActive(false);
                cam1static.SetActive(false);
            }
            else
            {
                petercam1.gameObject.SetActive(false);
                shitdatindewegzit.SetActive(false);
                currentlocation = "office";
                officepeter.gameObject.SetActive(true);
                camerahandler.GetComponent<Cameras>().SwitchToCamDown(true);
                camerahandler.GetComponent<Cameras>().BackToTheOffice(true);
                Peterjumpscaresound.Play();
                officepeter.gameObject.GetComponent<animplayer>().Func_PlayUIAnim();

                yield return new WaitForSeconds(0.4f);
                // Wait for a few seconds after the jumpscare before changing the scene // Change 3f to your desired delay

                // Load the next scene
                SceneManager.LoadScene("GameOver"); // Replace "YourNextScene" with your scene name
            }
        }
        if (currentlocation == "buiten")
        {


            yield return new WaitForSeconds(8f);

            if (currentlocation == "buiten")
            {
                shitdatindewegzit.SetActive(false);
                currentlocation = "office";
                officeraam.gameObject.SetActive(true);
                camerahandler.GetComponent<Cameras>().SwitchToCamDown(true);
                camerahandler.GetComponent<Cameras>().BackToTheOffice(true);
                Peterjumpscaresound.Play();
                breakraam.Play();
                officeraam.gameObject.GetComponent<animplayer>().Func_PlayUIAnim();

                yield return new WaitForSeconds(0.9f);
                // Wait for a few seconds after the jumpscare before changing the scene // Change 3f to your desired delay

                // Load the next scene
                SceneManager.LoadScene("GameOver"); // Replace "YourNextScene" with your scene name
            }
        }

            StartCoroutine(peterMover());
    }

    IEnumerator peterbutton()
    {
        buttonunpressed.SetActive(false);
        pressbuttonsound.Play();
        if (currentlocation == "buiten")
        {
            rocitstatic.SetActive(true);
            currentlocation = "stage1";
            peterROCITstage1.gameObject.SetActive(true);

            // Randomly select an audio clip
            wallsound.Play();

            yield return new WaitForSeconds(0.1f);
            rocitstatic.SetActive(false);
        }
        buttonpressed.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        shanksound.Play();
        spike.SetActive(true);
        yield return new WaitForSeconds(11.5f);
        spike.SetActive(false);
        buttonpressed.SetActive(false);
        buttonunpressed.SetActive(true);

    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnknownAI : MonoBehaviour
{
    private string currentlocation;

    public int ailevel;

    private int hallwindow;

    public GameObject Hidden;
    public GameObject Cam1;
    public GameObject Cam2;

    public GameObject jumpscareobject;

    public GameObject cam2static;
    public GameObject cam1static;

    public GameObject shitdatindewegzit;

    public AudioSource gonegeluid;
    public Canvas deurui;
    public GameObject doorcam;
    public Button backtoofficebutton;
    public GameObject camerahandler;
    public AudioSource jumpscare;

    void Start()
    {
        currentlocation = "hidden";
        StartCoroutine(UnknownMove());
    }

    IEnumerator UnknownMove()
    {
        yield return new WaitForSeconds(5f);

        int chance = UnityEngine.Random.Range(1, 21);
        Debug.Log(chance);

        if (chance <= ailevel)
        {
            if (currentlocation == "hidden")
            {
                Hidden.gameObject.SetActive(false);
                currentlocation = "cam2";
                Cam2.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }
            else if (currentlocation == "cam2")
            {
                Cam2.gameObject.SetActive(false);
                currentlocation = "cam1";
                Cam1.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }
            else if (currentlocation == "cam1")
            {
                yield return new WaitForSeconds(8f);
                if (doorcam.activeSelf && !(backtoofficebutton.IsActive()))
                {
                    Cam1.gameObject.SetActive(false);
                    currentlocation = "hidden";
                    Hidden.gameObject.SetActive(true);
                }
                else
                {
                    Cam1.gameObject.SetActive(false);
                    shitdatindewegzit.SetActive(false); 
                    backtoofficebutton.gameObject.SetActive(false);
                    currentlocation = "office";
                    camerahandler.GetComponent<Cameras>().SwitchToCamDown(true);
                    camerahandler.GetComponent<Cameras>().BackToTheOffice(true);
                    jumpscareobject.gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.4f);

                    // Wait for a few seconds after the jumpscare before changing the scene
                    // Change 3f to your desired delay

                    // Load the next scene
                    SceneManager.LoadScene("GameOver"); // Replace "YourNextScene" with your scene name
                }
            }
            StartCoroutine(UnknownMove());
        }
    }
}
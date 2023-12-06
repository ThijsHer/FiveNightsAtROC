using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulAI : MonoBehaviour
{
    public GameObject paulphase5;
    public GameObject paulphase4;
    public GameObject paulphase3;
    public GameObject paulphase2;
    public GameObject paulphase1;

    public GameObject audiolure;

    public AudioSource poephoofd;
    public AudioSource wifi;

    public GameObject staticcam8;

    private string currentlocation;
    public int ailevel;

    public GameObject camerahandler;
    public GameObject cambutton;
    void Start()
    {
        currentlocation = "paulphase1";
        StartCoroutine(paulMovement());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator paulMovement()
    {
        yield return new WaitForSeconds(5f);

        int chance = UnityEngine.Random.Range(1, 21);
        Debug.Log(chance);

        if (chance <= ailevel)
        {
            if (currentlocation == "paulphase1")
            {
                staticcam8.SetActive(true);
                paulphase1.gameObject.SetActive(false);
                currentlocation = "paulphase2";
                paulphase2.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam8.SetActive(false);
            }
            else if (currentlocation == "paulphase2")
            {
                staticcam8.SetActive(true);
                paulphase2.gameObject.SetActive(false);
                currentlocation = "paulphase3";
                paulphase3.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam8.SetActive(false);
            }
            else if (currentlocation == "paulphase3")
            {
                staticcam8.SetActive(true);
                paulphase3.gameObject.SetActive(false);
                currentlocation = "paulphase4";
                paulphase4.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam8.SetActive(false);
            }
            else if (currentlocation == "paulphase4")
            {
                staticcam8.SetActive(true);
                paulphase4.gameObject.SetActive(false);
                currentlocation = "paulphase5";
                paulphase5.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam8.SetActive(false);
            }
            else if (currentlocation == "paulphase5")
            {
                camerahandler.GetComponent<Cameras>().SwitchToCamDown(false);
                cambutton.SetActive(false);
                wifi.Play();
                currentlocation = "pauldown";
            }

        }
        StartCoroutine(paulMovement());
    }


    public void callpaul()
    {
        StartCoroutine(Lure());
    }
    IEnumerator Lure() {
        audiolure.SetActive(false);
        poephoofd.Play();
        if (currentlocation == "paulphase4" || currentlocation == "paulphase5")
        {
            currentlocation = "pauldown";
            yield return new WaitForSeconds(poephoofd.clip.length);

            staticcam8.SetActive(true);
            paulphase4.gameObject.SetActive(false);
            paulphase5.gameObject.SetActive(false);
            currentlocation = "paulphase1";
            paulphase1.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            staticcam8.SetActive(false);
        }
        else
        {
            yield return new WaitForSeconds(poephoofd.clip.length);
            staticcam8.SetActive(true);

        }
        yield return new WaitForSeconds(10f);
        audiolure.SetActive(true);
    }
}


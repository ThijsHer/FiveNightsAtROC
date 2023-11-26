using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RICK : MonoBehaviour
{
    public GameObject rickcam7;
    public GameObject rickcam6;
    public GameObject rickcam5;
    public GameObject rickcam3;
    public GameObject rickcam1;
    public GameObject rickoffice;
    public GameObject camerahandler;
    public AudioSource rickjumpscaresound;
    private string currentlocation;
    public int ailevel;

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
                currentlocation = "cam3";
                rickcam3.gameObject.SetActive(true);
            }
            else if (currentlocation == "cam3")
            {
                rickcam3.gameObject.SetActive(false);
                currentlocation = "cam1";
                rickcam1.gameObject.SetActive(true);
            }
            else if (currentlocation == "cam1")
            {
                rickcam1.gameObject.SetActive(false);
                currentlocation = "office";
                rickoffice.gameObject.SetActive(true);
                camerahandler.GetComponent<Cameras>().SwitchToCamDown();
                rickjumpscaresound.Play();
            }
        }
        StartCoroutine(rickMovement());
    }
}

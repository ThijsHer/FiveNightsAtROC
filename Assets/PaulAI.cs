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

    public GameObject staticcam8;

    private string currentlocation;
    public int ailevel;
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
            StartCoroutine(paulMovement());
        }
    }
}


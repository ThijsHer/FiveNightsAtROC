using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PaulAI : MonoBehaviour
{
    public GameObject paulscare;
    public GameObject paulscare2;
    public GameObject paulphase5;
    public GameObject paulphase4;
    public GameObject paulphase3;
    public GameObject paulphase2;
    public GameObject paulphase1;

    public GameObject audiolure;


    public AudioSource poephoofd;
    public AudioSource wifi;
    public AudioSource break1;
    public AudioSource break2;
    public AudioSource paulgression;
    public AudioSource angry;

    public GameObject staticcam8;
    public GameObject cambrokenui;
    public GameObject wifilogo;
    public GameObject rebootbtn;

    [SerializeField]
    private ButtonHoldRelease camResetBtn;

    private string currentlocation;
    public int ailevel;

    public GameObject camerahandler;
    public GameObject cambutton;

    private Coroutine coroutine;

    private void Awake()
    {
        camResetBtn.WifiFixed += ResetCam;

    }

    void Start()
    {
        currentlocation = "paulphase1";
        StartCoroutine(paulMovement());
    }

    // Update is called once per frame
    void Update()
    {

    }

    [SerializeField] float jumpHeight = 0.2f; // Adjust this value for the jump height
    [SerializeField] float jumpDuration = 0.5f; // Adjust this value for the jump duration

    IEnumerator JumpEffect(GameObject obj)
    {
        float originalY = obj.transform.position.y;
        float jumpHeight = 1.0f; // Change this value to adjust jump height
        float jumpDuration = 0.5f; // Change this value to adjust jump duration

        float timeElapsed = 0;

        while (timeElapsed < jumpDuration)
        {
            float newY = originalY + Mathf.Sin(Mathf.PI * (timeElapsed / jumpDuration)) * jumpHeight;
            obj.transform.position = new Vector3(obj.transform.position.x, newY, obj.transform.position.z);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = new Vector3(obj.transform.position.x, originalY, obj.transform.position.z);
        StartCoroutine(JumpEffect(paulphase5.gameObject));
    }

    IEnumerator paulMovement()
    {
        yield return new WaitForSeconds(5f);

        int chance = UnityEngine.Random.Range(1, 21);

        if (chance <= ailevel)
        {
            if (currentlocation == "paulphase1")
            {
                paulgression.Play();
                staticcam8.SetActive(true);
                paulphase1.gameObject.SetActive(false);
                currentlocation = "paulphase2";
                paulphase2.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam8.SetActive(false);
            }
            else if (currentlocation == "paulphase2")
            {
                paulgression.Play();
                staticcam8.SetActive(true);
                paulphase2.gameObject.SetActive(false);
                currentlocation = "paulphase3";
                paulphase3.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam8.SetActive(false);
            }
            else if (currentlocation == "paulphase3")
            {
                paulgression.Play();
                staticcam8.SetActive(true);
                paulphase3.gameObject.SetActive(false);
                currentlocation = "paulphase4";
                paulphase4.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam8.SetActive(false);
            }
            else if (currentlocation == "paulphase4")
            {
                paulgression.Play();
                staticcam8.SetActive(true);
                paulphase4.gameObject.SetActive(false);
                currentlocation = "paulphase5";
                paulphase5.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticcam8.SetActive(false);
                StartCoroutine(JumpEffect(paulphase5.gameObject));
            }
        }
        if (currentlocation == "paulphase5")
        {
            yield return new WaitForSeconds(8f);
            if (currentlocation == "paulphase5")
            {
                camerahandler.GetComponent<Cameras>().SwitchToCamDown(false);
                cambutton.SetActive(false);
                wifi.Play();
                currentlocation = "pauldown";
                wifilogo.gameObject.SetActive(true);
                wifilogo.GetComponent<logoflicker>().start();
                yield return new WaitForSeconds(2f);
                rebootbtn.gameObject.SetActive(true);
            }
        }


        StartCoroutine(paulMovement());
    }

    public void callpaul()
    {
        StartCoroutine(Lure());
    }
    IEnumerator Lure()
    {
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
            if (cambrokenui.activeSelf)
            {
                camerahandler.GetComponent<Cameras>().SwitchToCamDown(true);
                camerahandler.GetComponent<Cameras>().BackToTheOffice(true);
                currentlocation = "pauldown";
                paulphase1.SetActive(false);
                paulphase2.SetActive(false);
                paulphase3.SetActive(false);
                paulscare2.SetActive(true);
                yield return new WaitForSeconds(poephoofd.clip.length);
                angry.Play();
                paulscare2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                yield return new WaitForSeconds(0.1f);
                paulscare2.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                yield return new WaitForSeconds(0.1f);
                paulscare2.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                yield return new WaitForSeconds(0.1f);
                paulscare2.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
                yield return new WaitForSeconds(0.1f);
                paulscare2.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                yield return new WaitForSeconds(0.1f);
                paulscare2.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                yield return new WaitForSeconds(0.1f);
                paulscare2.transform.localScale = new Vector3(3f, 3f, 3f);
                yield return new WaitForSeconds(0.1f);
                break1.Play();
                break2.Play();
                SceneManager.LoadScene("GameOver");

            }
            else {
                string previousloc = currentlocation;
                currentlocation = "pauldown";
                paulphase1.SetActive(false);
                paulphase2.SetActive(false);
                paulphase3.SetActive(false);
                paulscare.SetActive(true);
                yield return new WaitForSeconds(poephoofd.clip.length);
                angry.Play();
                paulscare.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                yield return new WaitForSeconds(0.1f);
                paulscare.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                yield return new WaitForSeconds(0.1f);
                paulscare.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                yield return new WaitForSeconds(0.1f);
                paulscare.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
                yield return new WaitForSeconds(0.1f);
                paulscare.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                yield return new WaitForSeconds(0.1f);
                paulscare.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                yield return new WaitForSeconds(0.1f);
                paulscare.transform.localScale = new Vector3(3f, 3f, 3f);
                yield return new WaitForSeconds(0.1f);
                break1.Play();
                break2.Play();

                cambrokenui.SetActive(true);
                currentlocation = previousloc; }

        }
        yield return new WaitForSeconds(10f);
        audiolure.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    private void ResetCam()
    {
        cambutton.SetActive(true);
        wifilogo.gameObject.SetActive(false);
        currentlocation = "paulphase1";
        paulphase1.gameObject.SetActive(true);
        paulphase5.gameObject.SetActive(false);
        wifilogo.GetComponent<logoflicker>().stop();
    }
}


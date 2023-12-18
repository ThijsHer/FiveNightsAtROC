using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Cameras : MonoBehaviour
{
    public Camera Office;
    public Camera Cam1;
    public Camera Cam2;
    public Camera Cam3;
    public Camera Cam4;
    public Camera Cam5;
    public Camera Cam6;
    public Camera Cam7;
    public Camera Cam8;
    public Camera Cam9;
    public Camera closedoorcam;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button Button7;
    public Button Button8;
    public Button Button9;

    public Button backtoofficebutton;

    public GameObject CamUpObject;
    public GameObject CamDownObject;
    public GameObject DEURUI;
    AudioSource camswitcher;
    AudioSource camOpener;
    public Animator deurdichtanim;


    public GameObject staticcam9;
    public GameObject staticcam8;
    public GameObject staticcam7;
    public GameObject staticcam6;
    public GameObject staticcam5;
    public GameObject staticcam4;
    public GameObject staticcam3;
    public GameObject staticcam2;
    public GameObject staticcam1;

    public TMP_Text buttontext;



    private int SelectedCam = 1;


    // Start is called before the first frame update
    void Start()
    {
        camswitcher = GetComponent<AudioSource>();
        camOpener = CamDownObject.GetComponent<AudioSource>();
        Office.gameObject.SetActive(true);
        Cam1.gameObject.SetActive(false);
        Cam2.gameObject.SetActive(false);
        Cam3.gameObject.SetActive(false);
        Cam4.gameObject.SetActive(false);
        Cam5.gameObject.SetActive(false);
        Cam6.gameObject.SetActive(false);
        Cam7.gameObject.SetActive(false);
        Cam8.gameObject.SetActive(false);
        Cam9.gameObject.SetActive(false);

        Button1.interactable = false;
        Button2.interactable = true;
        Button3.interactable = true;
        Button4.interactable = true;
        Button5.interactable = true;
        Button6.interactable = true;
        Button7.interactable = true;
        Button8.interactable = true;
        Button9.interactable = true;

        CamUpObject.SetActive(true);
        CamDownObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToDoor()
    {
        StartCoroutine(todooranim());

    }

    public void ShutDoor()
    {
        if (!(backtoofficebutton.IsActive()))
        {
            OpenDoor();
        }
        else
        {
            deurdichtanim.Play("CLOSEDOOR", -1, 0f);
            backtoofficebutton.gameObject.SetActive(false);
            buttontext.SetText("open");
        }
    }

    private void OpenDoor() {
        deurdichtanim.Play("OPENDOOR", -1, 0f);
        backtoofficebutton.gameObject.SetActive(true);
        buttontext.SetText("close");
    }

    public void BackToTheOffice(Boolean externaltrigger)
    {

        if (externaltrigger && DEURUI.activeSelf)
        {
            Debug.Log("no game");
            Office.gameObject.SetActive(true);

            DEURUI.SetActive(false);
            closedoorcam.gameObject.SetActive(false);
            Office.transform.Translate(3, -1, 0);
            Office.orthographicSize = 5;
        }
        else if (externaltrigger && !(DEURUI.activeSelf))
        {
            Debug.Log("triple gawk");
            Office.gameObject.SetActive(true);

            DEURUI.SetActive(false);
            closedoorcam.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(toofficeanim());
        }
        

    }
    IEnumerator SelectCam()
    {
        Cam1.gameObject.SetActive(false);
        Cam2.gameObject.SetActive(false);
        Cam3.gameObject.SetActive(false);
        Cam4.gameObject.SetActive(false);
        Cam5.gameObject.SetActive(false);
        Cam6.gameObject.SetActive(false);
        Cam7.gameObject.SetActive(false);
        Cam8.gameObject.SetActive(false);
        Cam9.gameObject.SetActive(false);

        Button1.interactable = true;
        Button2.interactable = true;
        Button3.interactable = true;
        Button4.interactable = true;
        Button5.interactable = true;
        Button6.interactable = true;
        Button7.interactable = true;
        Button8.interactable = true;
        Button9.interactable = true;

        if (SelectedCam == 1)
        {
            
            Cam1.gameObject.SetActive(true);
            Button1.interactable = false;
            staticcam1.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            staticcam1.SetActive(false);
        }
        else if (SelectedCam == 2)
        {
            Cam2.gameObject.SetActive(true);
            Button2.interactable = false;
            staticcam2.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            staticcam2.SetActive(false);
        }
        else if (SelectedCam == 3)
        {
            Cam3.gameObject.SetActive(true);
            Button3.interactable = false;
            staticcam3.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            staticcam3.SetActive(false);
        }
        else if (SelectedCam == 4)
        {
            Cam4.gameObject.SetActive(true);
            Button4.interactable = false;
            staticcam4.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            staticcam4.SetActive(false);
        }
        else if (SelectedCam == 5)
        {
            Cam5.gameObject.SetActive(true);
            Button5.interactable = false;
            staticcam5.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            staticcam5.SetActive(false);
        }
        else if (SelectedCam == 6)
        {
            Cam6.gameObject.SetActive(true);
            Button6.interactable = false;
            staticcam6.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            staticcam6.SetActive(false);
        }
        else if (SelectedCam == 7)
        {
            Cam7.gameObject.SetActive(true);
            Button7.interactable = false;
            staticcam7.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            staticcam7.SetActive(false);
        }
        else if (SelectedCam == 8)
        {
            Cam8.gameObject.SetActive(true);
            Button8.interactable = false;
            staticcam8.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            staticcam8.SetActive(false);
        }
        else if (SelectedCam == 9)
        {
            Cam9.gameObject.SetActive(true);
            Button9.interactable = false;
            staticcam9.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            staticcam9.SetActive(false);
        }
    }

    public void SwitchToCamUp()
    {

        StartCoroutine(camonanim());

    }

    public void SwitchToCamDown(Boolean externaltrigger)
    {

        if (externaltrigger && !(CamDownObject.activeSelf))
        {
            Office.gameObject.SetActive(true);
            Cam1.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
            Cam4.gameObject.SetActive(false);
            Cam5.gameObject.SetActive(false);
            Cam6.gameObject.SetActive(false);
            Cam7.gameObject.SetActive(false);
            Cam8.gameObject.SetActive(false);
            Cam9.gameObject.SetActive(false);
            CamDownObject.SetActive(false);

        }
        else if (externaltrigger && CamDownObject)
        {
            Office.gameObject.SetActive(true);
            Cam1.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
            Cam4.gameObject.SetActive(false);
            Cam5.gameObject.SetActive(false);
            Cam6.gameObject.SetActive(false);
            Cam7.gameObject.SetActive(false);
            Cam8.gameObject.SetActive(false);
            Cam9.gameObject.SetActive(false);
            CamDownObject.SetActive(false);
            Office.transform.Translate(0, 1, 0);
            Office.orthographicSize = 5;
        }
        else if (!(CamDownObject.activeSelf)) {
            Office.gameObject.SetActive(true);
            Cam1.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
            Cam4.gameObject.SetActive(false);
            Cam5.gameObject.SetActive(false);
            Cam6.gameObject.SetActive(false);
            Cam7.gameObject.SetActive(false);
            Cam8.gameObject.SetActive(false);
            Cam9.gameObject.SetActive(false);
            CamDownObject.SetActive(false);
        }
        else
        {
            StartCoroutine(camoffanim());
        }
    }

    public void Camera1()
    {

        SelectedCam = 1;
        StartCoroutine(SelectCam());
        camswitcher.Play();
    }
    public void Camera2()
    {
        SelectedCam = 2;
        StartCoroutine(SelectCam());
        camswitcher.Play();
    }

    public void Camera3()
    {
        SelectedCam = 3;
        StartCoroutine(SelectCam());
        camswitcher.Play();
    }
    public void Camera4()
    {
        SelectedCam = 4;
        StartCoroutine(SelectCam());
        camswitcher.Play();
    }

    public void Camera5()
    {
        SelectedCam = 5;
        StartCoroutine(SelectCam());
        camswitcher.Play();
    }

    public void Camera6()
    {
        SelectedCam = 6;
        StartCoroutine(SelectCam());
        camswitcher.Play();
    }

    public void Camera7()
    {
        SelectedCam = 7;
        StartCoroutine(SelectCam());
        camswitcher.Play();
    }

    public void Camera8()
    {
        SelectedCam = 8;
        StartCoroutine(SelectCam());
        camswitcher.Play();
    }

    public void Camera9()
    {
        SelectedCam = 9;
        StartCoroutine(SelectCam());
        camswitcher.Play();
    }


    IEnumerator camonanim()
    {
        CamUpObject.SetActive(false);
        Office.orthographicSize = 4;
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 3;
        yield return new WaitForSeconds(0.1f);
        Office.transform.Translate(0, -1, 0);
        Office.orthographicSize = 2;
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 1;
        yield return new WaitForSeconds(0.1f);
        Office.gameObject.SetActive(false);
        StartCoroutine(SelectCam());


        
        CamDownObject.SetActive(true);
        camOpener.Play();

    }
    IEnumerator camoffanim()
    {
        Office.gameObject.SetActive(true);
        Cam1.gameObject.SetActive(false);
        Cam2.gameObject.SetActive(false);
        Cam3.gameObject.SetActive(false);
        Cam4.gameObject.SetActive(false);
        Cam5.gameObject.SetActive(false);
        Cam6.gameObject.SetActive(false);
        Cam7.gameObject.SetActive(false);
        Cam8.gameObject.SetActive(false);
        Cam9.gameObject.SetActive(false);
        CamDownObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 2;
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 3;
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 4;
        Office.transform.Translate(0, 1, 0);
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 5;
        CamUpObject.SetActive(true);
    }

    IEnumerator todooranim()
    {
        CamUpObject.SetActive(false);
        Office.orthographicSize = 4;
        Office.transform.Translate(-1, 1, 0);
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 3;
        Office.transform.Translate(-1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 2;
        Office.transform.Translate(-1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 1;
        yield return new WaitForSeconds(0.1f);
        Office.gameObject.SetActive(false);
        
        DEURUI.SetActive(true);
        closedoorcam.gameObject.SetActive(true);
    }
    IEnumerator toofficeanim()
    {
        Office.gameObject.SetActive(true);

        DEURUI.SetActive(false);
        closedoorcam.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 2;
        Office.transform.Translate(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 3;
        Office.transform.Translate(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 4;
        Office.transform.Translate(1, -1, 0);
        yield return new WaitForSeconds(0.1f);
        Office.orthographicSize = 5;
        yield return new WaitForSeconds(0.1f);
        CamUpObject.SetActive(true);


    }



}


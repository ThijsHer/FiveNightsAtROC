using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public Camera closedoorcam;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button Button7;
    public Button Button8;

    public Button backtoofficebutton;

    public GameObject CamUpObject;
    public GameObject CamDownObject;
    public GameObject DEURUI;
    AudioSource camswitcher;
    AudioSource camOpener;
    public Animator deurdichtanim;


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

        Button1.interactable = false;
        Button2.interactable = true;
        Button3.interactable = true;
        Button4.interactable = true;
        Button5.interactable = true;
        Button6.interactable = true;
        Button7.interactable = true;
        Button8.interactable = true;

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

    public void BackToTheOffice()
    {
        StartCoroutine (toofficeanim());

    }
    private void SelectCam()
    {
        Cam1.gameObject.SetActive(false);
        Cam2.gameObject.SetActive(false);
        Cam3.gameObject.SetActive(false);
        Cam4.gameObject.SetActive(false);
        Cam5.gameObject.SetActive(false);
        Cam6.gameObject.SetActive(false);
        Cam7.gameObject.SetActive(false);
        Cam8.gameObject.SetActive(false);

        Button1.interactable = true;
        Button2.interactable = true;
        Button3.interactable = true;
        Button4.interactable = true;
        Button5.interactable = true;
        Button6.interactable = true;
        Button7.interactable = true;
        Button8.interactable = true;

        if (SelectedCam == 1)
        {
            Cam1.gameObject.SetActive(true);
            Button1.interactable = false;
        }
        else if (SelectedCam == 2)
        {
            Cam2.gameObject.SetActive(true);
            Button2.interactable = false;
        }
        else if (SelectedCam == 3)
        {
            Cam3.gameObject.SetActive(true);
            Button3.interactable = false;
        }
        else if (SelectedCam == 4)
        {
            Cam4.gameObject.SetActive(true);
            Button4.interactable = false;
        }
        else if (SelectedCam == 5)
        {
            Cam5.gameObject.SetActive(true);
            Button5.interactable = false;
        }
        else if (SelectedCam == 6)
        {
            Cam6.gameObject.SetActive(true);
            Button6.interactable = false;
        }
        else if (SelectedCam == 7)
        {
            Cam7.gameObject.SetActive(true);
            Button7.interactable = false;
        }
        else if (SelectedCam == 8)
        {
            Cam8.gameObject.SetActive(true);
            Button8.interactable = false;
        }
    }

    public void SwitchToCamUp()
    {

        StartCoroutine(camonanim());

    }

    public void SwitchToCamDown()
    {
        StartCoroutine (camoffanim());
    }

    public void Camera1()
    {
        SelectedCam = 1;
        SelectCam();
        camswitcher.Play();
    }
    public void Camera2()
    {
        SelectedCam = 2;
        SelectCam();
        camswitcher.Play();
    }

    public void Camera3()
    {
        SelectedCam = 3;
        SelectCam();
        camswitcher.Play();
    }
    public void Camera4()
    {
        SelectedCam = 4;
        SelectCam();
        camswitcher.Play();
    }

    public void Camera5()
    {
        SelectedCam = 5;
        SelectCam();
        camswitcher.Play();
    }

    public void Camera6()
    {
        SelectedCam = 6;
        SelectCam();
        camswitcher.Play();
    }

    public void Camera7()
    {
        SelectedCam = 7;
        SelectCam();
        camswitcher.Play();
    }

    public void Camera8()
    {
        SelectedCam = 8;
        SelectCam();
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
        SelectCam();


        
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


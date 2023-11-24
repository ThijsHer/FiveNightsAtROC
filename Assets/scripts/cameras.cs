using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button Button7;
    public Button Button8;

    public GameObject CamUpObject;
    public GameObject CamDownObject;
    AudioSource camswitcher;
    AudioSource camOpener;


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
        Office.gameObject.SetActive(false);
        Debug.Log(camOpener);
        SelectCam();


        CamUpObject.SetActive(false);
        CamDownObject.SetActive(true);
        camOpener.Play();
    }

    public void SwitchToCamDown()
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
        CamUpObject.SetActive(true);
        CamDownObject.SetActive(false);
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
}


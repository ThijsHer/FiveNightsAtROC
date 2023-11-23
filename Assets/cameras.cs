using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject CamUpObject;
    public GameObject CamDownObject;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchToCamUp()
    {
        Office.gameObject.SetActive(false);
        Cam1.gameObject.SetActive(true);
        Cam2.gameObject.SetActive(false);
        Cam3.gameObject.SetActive(false);
        Cam4.gameObject.SetActive(false);
        Cam5.gameObject.SetActive(false);
        Cam6.gameObject.SetActive(false);
        Cam7.gameObject.SetActive(false);
        Cam8.gameObject.SetActive(false);

        CamUpObject.SetActive(false);
        CamDownObject.SetActive(true);
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
}


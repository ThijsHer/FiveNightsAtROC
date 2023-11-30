using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phoneguycall : MonoBehaviour
{
    public AudioSource Ring;
    public AudioSource Yap;
    public AudioSource Click;

    private Boolean hangupcheck;
    private Boolean pickupcheck;
    void Start()
    {
        hangupcheck = false; pickupcheck = false ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pickup()
    {
        Debug.Log("test");
        if (pickupcheck)
        {
            hangup();
        }
        else
        {
            pickupcheck = true;
            Ring.Stop();
            Yap.Play();
            StartCoroutine(Yaptime());
        }

    }

    public void hangup()
    {
        if (hangupcheck == false)
        {
            Yap.Stop();
            Click.Play();
            hangupcheck = true;
        }

    }

    IEnumerator Yaptime()
    {
        yield return new WaitForSeconds(Yap.clip.length);
        hangup();

    }
}

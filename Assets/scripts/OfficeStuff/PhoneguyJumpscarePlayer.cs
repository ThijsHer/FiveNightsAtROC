using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneguyJumpscarePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    AudioSource Sound;
    void Start()
    {
        anim = GetComponent<Animator>();
        Sound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    public void Playjumpscarephoneguy()
    {
        Sound.Play();
        anim.Play("PhoneJumpscare");
        
    }
}

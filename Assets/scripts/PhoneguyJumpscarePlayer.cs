using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneguyJumpscarePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    public void Playjumpscarephoneguy()
    {
        anim.Play("PhoneJumpscare");
    }
}

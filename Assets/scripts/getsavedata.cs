using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getsavedata : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetString("currentnight", "night1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

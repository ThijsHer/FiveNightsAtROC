using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class getsavedata : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text buttonnight;
    void Start()
    {
        string currentnight = PlayerPrefs.GetString("currentnight", "Night 1");
        buttonnight.text = currentnight;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

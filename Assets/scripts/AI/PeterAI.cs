using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeterAI : MonoBehaviour
{
    private string currentlocation;

    public int ailevel;

    public GameObject peterROCITstage1;
    public GameObject peterROCITstage2;
    public GameObject peterROCITstage3;
    public GameObject petercam3;
    public GameObject petercam1;

    void Start()
    {
        currentlocation = "stage1";
        StartCoroutine(peterMover());
    }

    IEnumerator peterMover()
    {
        yield return new WaitForSeconds(5f);

        int chance = UnityEngine.Random.Range(1, 21);
        Debug.Log(chance);

        if (chance <= ailevel)
        {
            if (currentlocation == "stage1")
            {

            }
        }
    }
}



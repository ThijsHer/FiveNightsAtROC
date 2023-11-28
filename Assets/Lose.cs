using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changesceneLoad());
    }



    // Update is called once per frame
    IEnumerator changesceneLoad()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Mainmenu");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 0;
    public AudioSource clip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changesceneLoad());
    }



    // Update is called once per frame
    IEnumerator changesceneLoad()
    {
        yield return new WaitForSeconds(clip.clip.length);
        SceneManager.LoadScene("Mainmenu");

    }

    public void skipbacktomenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}

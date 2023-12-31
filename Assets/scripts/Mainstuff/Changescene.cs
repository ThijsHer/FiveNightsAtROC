using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescene : MonoBehaviour
{
    public float timer = 0;
    public AudioSource clip;
    private string currentnight;
    // Start is called before the first frame update
    void Start()
    {
        currentnight = PlayerPrefs.GetString("currentnight", "Night 1");
        StartCoroutine(changesceneLoad());
    }



    // Update is called once per frame
    IEnumerator changesceneLoad()
    {
        yield return new WaitForSeconds(clip.clip.length);
        if (currentnight == "Night 1")
        {
            SceneManager.LoadScene("Night1");
        }
        else if (currentnight == "Night 2")
        {
            SceneManager.LoadScene("Night2");
        }

    }

    public void skiptonight()
    {
        if (currentnight == "Night 1")
        {
            SceneManager.LoadScene("Night1");
        }
        else if (currentnight == "Night 2")
        {
            SceneManager.LoadScene("Night2");
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Memevideos : MonoBehaviour
{
    public List<VideoClip> videoClips;
    public GameObject targetObject;

    private VideoPlayer videoPlayer;

    void Start()
    {
        if (targetObject == null)
        {
            targetObject = gameObject;
        }
        int randomIndex = Random.Range(0, videoClips.Count);
        VideoClip randomVideoClip = videoClips[randomIndex];

        videoPlayer = targetObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = true;
        videoPlayer.clip = randomVideoClip;
        videoPlayer.loopPointReached += OnVideoEnd;

        videoPlayer.Play();
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("secretnight");
    }
}

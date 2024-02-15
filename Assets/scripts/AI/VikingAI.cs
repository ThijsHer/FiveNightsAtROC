using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VikingAI : MonoBehaviour
{
    private string currentLocation;

    public int aiLevel;

    private int randomroom;

    public AudioSource music;

    public AudioSource walk;
    public AudioSource voiceline;

    public GameObject jumpscareObject;
    public GameObject jumpscareviking;
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;
    public GameObject stage5;
    public GameObject rocit;
    public GameObject serverroom;
    public GameObject snowballStage1;
    public GameObject snowballStage2;
    public GameObject snowballStage3;
    public GameObject snowballStage4;
    public GameObject snowballrocit;
    public GameObject snowballserverroom;

    public GameObject cam6static;
    public GameObject cam5static;
    public GameObject cam4static;
    public GameObject cam3static;
    public GameObject cam1static;
    public GameObject rocitstatic;
    public GameObject serverroomstatic;

    public GameObject snowballSplatterStage1;
    public GameObject snowballSplatterStage2;
    public GameObject snowballSplatterStage3;
    public GameObject snowballSplatterStage4;
    public GameObject snowballSplatterrocit;
    public GameObject snowballSplatterserverroom;

    public float throwDuration = 1.5f;
    public float splatterDuration = 12f;

    public Canvas doorUI;
    public GameObject doorCam;
    public Button backToOfficeButton;
    public AudioSource jumpscareSound;
    public GameObject shitdatindewegzit;
    public GameObject camerahandler;



    void Start()
    {
        currentLocation = "stage1";
        StartCoroutine(VikingMove());
        music.Play();
    }

    IEnumerator VikingMove()
    {
        yield return new WaitForSeconds(5f);

        int chance = Random.Range(1, 21);
        Debug.Log(chance);

        if (chance <= aiLevel)
        {
            if (currentLocation == "stage1") //cam6
            {
                randomroom = UnityEngine.Random.Range(1, 3);
                StartCoroutine(ThrowSnowball(snowballStage1, snowballSplatterStage1));
                stage1.SetActive(false);
                currentLocation = "stage2";
                stage2.SetActive(true);
                cam6static.SetActive(true);
                cam5static.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                cam6static.SetActive(false);
                cam5static.SetActive(false);
            }
            else if (currentLocation == "stage2") //cam5
            {
                if (randomroom == 2)
                {
                    currentLocation = "rocit";
                    StartCoroutine(ThrowSnowball(snowballStage2, snowballSplatterStage2));
                    stage2.gameObject.SetActive(false);
                    rocit.gameObject.SetActive(true);
                    cam5static.SetActive(true);
                    rocitstatic.SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                    cam5static.SetActive(false);
                    rocitstatic.SetActive(false);
                }
                else
                {
                    randomroom = UnityEngine.Random.Range(1, 3);
                    StartCoroutine(ThrowSnowball(snowballStage2, snowballSplatterStage2));
                    stage2.SetActive(false);
                    currentLocation = "stage3";
                    stage3.SetActive(true);
                    cam5static.SetActive(true);
                    cam4static.SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                    cam5static.SetActive(false);
                    cam4static.SetActive(false);
                }
            }
            else if (currentLocation == "rocit")
            {
                StartCoroutine(ThrowSnowball(snowballrocit, snowballSplatterrocit));
                currentLocation = "stage3"; // This seems to be a typo, should be "stage3" without space
                rocit.gameObject.SetActive(false);
                stage3.gameObject.SetActive(true);
                rocitstatic.SetActive(true);
                cam4static.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                rocitstatic.SetActive(false);
                cam4static.SetActive(false);
            }
            else if (currentLocation == "stage3") //cam4
            {
                if (randomroom == 1)
                {
                    StartCoroutine(ThrowSnowball(snowballStage3, snowballSplatterStage3));
                    currentLocation = "serverroom";
                    stage3.gameObject.SetActive(false);
                    serverroom.SetActive(true);
                    cam4static.SetActive(true);
                    serverroomstatic.SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                    cam4static.SetActive(false);
                    serverroomstatic.SetActive(false);
                }
                else
                {
                    StartCoroutine(ThrowSnowball(snowballStage3, snowballSplatterStage3));
                    stage3.SetActive(false);
                    currentLocation = "stage4";
                    stage4.SetActive(true);
                    cam4static.SetActive(true);
                    cam3static.SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                    cam4static.SetActive(false);
                    cam3static.SetActive(false);
                }
            }
            else if (currentLocation == "serverroom")
            {
                StartCoroutine(ThrowSnowball(snowballserverroom, snowballSplatterserverroom));
                currentLocation = "stage4"; // Assuming the next stage is stage4
                serverroom.SetActive(false); // Use SetActive instead of gameObject.SetActive
                stage4.SetActive(true); // Use SetActive instead of gameObject.SetActive
                serverroomstatic.SetActive(true);
                cam3static.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                cam3static.SetActive(false);
                serverroomstatic.SetActive(false);
            }
            else if (currentLocation == "stage4") //cam3
            {
                StartCoroutine(ThrowSnowball(snowballStage4, snowballSplatterStage4));
                stage4.SetActive(false);
                currentLocation = "stage5";
                stage5.SetActive(true);
                cam3static.SetActive(true);
                cam1static.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                cam3static.SetActive(false);
                cam1static.SetActive(false);
            }
            if (currentLocation == "stage5") //cam1
            {
                yield return new WaitForSeconds(8f);
                if (doorCam.activeSelf && !backToOfficeButton.IsActive())
                {
                    voiceline.Play();
                    walk.Play();
                    currentLocation = "stage1";
                    stage1.gameObject.SetActive(true);
                    stage5.gameObject.SetActive(false);
                    cam1static.SetActive(true);
                    cam6static.SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                    cam1static.SetActive(false);
                    cam6static.SetActive(false);
                }
                else
                {
                    jumpscareSound.Play();
                    music.Stop();
                    shitdatindewegzit.SetActive(false);
                    camerahandler.GetComponent<Cameras>().SwitchToCamDown(true);
                    camerahandler.GetComponent<Cameras>().BackToTheOffice(true);
                    backToOfficeButton.gameObject.SetActive(false);
                    jumpscareviking.gameObject.SetActive(true);
                    jumpscareviking.gameObject.GetComponent<animplayer>().Func_PlayUIAnim();

                    yield return new WaitForSeconds(7.3f);
                    // Load the next scene
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
        StartCoroutine(VikingMove());
    }

    IEnumerator ThrowSnowball(GameObject snowball, GameObject splatter)
    {
        snowball.SetActive(true); // Activate the snowball
        Vector3 originalScale = snowball.transform.localScale; // Save the original scale
        float elapsedTime = 0f;

        while (elapsedTime < throwDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / throwDuration;
            snowball.transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t); // Animate from small to original scale
            yield return null;
        }

        snowball.SetActive(false); // Deactivate the snowball after the throw animation completes

        // Activate snowball splatter
        splatter.SetActive(true);
        // Start coroutine to deactivate snowball splatter after specified duration
        StartCoroutine(DeactivateSplatterEffect(splatter, splatterDuration));
    }

    IEnumerator DeactivateSplatterEffect(GameObject splatter, float duration)
    {
        yield return new WaitForSeconds(duration);
        splatter.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageMovement : MonoBehaviour
{
    public GameObject[] toDoImages; // Array voor de image components aan de linkerkant (to-do)
    public GameObject[] busyImages; // Array voor de image components aan de rechterkant (busy)
    public float switchDelay = 5f; // Vertraging voordat de to-do images verdwijnen en de busy images verschijnen

    void Start()
    {
        // Activeer de busy image components en deactiveer de to-do image components
        ActivateToDoImages(false);
        ActivateBusyImages(true);
    }

    IEnumerator RandomizeBusyToToDo(GameObject busyImage)
    {
        // Willekeurige vertraging tussen 5 en 15 seconden
        float randomDelay = Random.Range(5f, 15f);
        yield return new WaitForSeconds(randomDelay);

        // Vind de index van de huidige image in de array
        int index = System.Array.IndexOf(busyImages, busyImage);

        // Deactiveer de busy image en activeer de overeenkomstige to-do image
        busyImage.SetActive(false);
        toDoImages[index].SetActive(true);
    }

    void ActivateToDoImages(bool activate)
    {
        // Activeer/deactiveer de to-do image components
        foreach (GameObject image in toDoImages)
        {
            image.SetActive(activate);

            // Schakel ook de Button component in of uit
            Button button = image.GetComponent<Button>();
            if (button != null)
            {
                button.enabled = activate;
            }
        }
    }

    void ActivateBusyImages(bool activate)
    {
        // Activeer/deactiveer de busy image components
        foreach (GameObject image in busyImages)
        {
 
            // Als we de busy images activeren, start dan de coroutine voor één van de objecten
            if (activate)
            {
                StartCoroutine(RandomizeBusyToToDo(image));
            }
        }
    }

    // Gebruik de OnClick methode van de Button component om te reageren op klikken op de to-do images
    public void OnToDoButtonClick(int index)
    {
        // Deactiveer de to-do image
        toDoImages[index].SetActive(false);

        // Activeer de bijbehorende busy image
        busyImages[index].SetActive(true);
    }
}

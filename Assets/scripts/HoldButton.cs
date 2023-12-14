using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonHoldRelease : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isButtonPressed = false;


    public event Action WifiFixed;

    bool isPressed = false;

    public Sprite redwifi;
    public Sprite bluereboot;
    public SpriteRenderer wifidown;

    [SerializeField]
    private float waittime = 10f;

    private float timer = 0;

    //link naar ui elementen

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Button Hold Down");
        isPressed = true;
        wifidown.sprite = bluereboot;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Button Release");
        isPressed = false;
        timer = 0;
        wifidown.sprite = redwifi;
    }

    private void Update()
    {
        if (isPressed)
        {
            timer += Time.deltaTime;

            if(timer >= waittime)
            {
                WifiFixed?.Invoke();
                Debug.Log($"{waittime} second have passed");
                isPressed = false;
                timer = 0;
                this.gameObject.SetActive(false);
                wifidown.sprite = redwifi;
            }
        }
    }
}

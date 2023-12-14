using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class animplayer : MonoBehaviour
{
    public SpriteRenderer m_Image;
    public Sprite[] m_SpriteArray;
    public float m_Speed = 0.1f;

    private int m_IndexSprite;
    private Coroutine m_CoroutineAnim;

    public Button backtoofficebutton;
    public TMP_Text buttontext;



    public void Func_PlayUIAnim()
    {

            if (m_CoroutineAnim != null)
                StopCoroutine(m_CoroutineAnim);

            m_IndexSprite = 0;
            m_CoroutineAnim = StartCoroutine(Func_PlayAnim(true));

    }

    public void Func_ReverseUIAnim()
    {
        if (m_CoroutineAnim != null)
            StopCoroutine(m_CoroutineAnim);

        m_IndexSprite = m_SpriteArray.Length - 1; // Start from the last sprite
        m_CoroutineAnim = StartCoroutine(Func_PlayAnim(false));
        backtoofficebutton.gameObject.SetActive(true);
        buttontext.text = "close";
    }

    IEnumerator Func_PlayAnim(bool playForward)
    {
        if (playForward)
        {
            while (m_IndexSprite < m_SpriteArray.Length)
            {
                m_Image.sprite = m_SpriteArray[m_IndexSprite];
                m_IndexSprite++;
                yield return new WaitForSeconds(m_Speed);
            }
        }
        else
        {
            while (m_IndexSprite >= 0)
            {
                m_Image.sprite = m_SpriteArray[m_IndexSprite];
                m_IndexSprite--;
                yield return new WaitForSeconds(m_Speed);
            }
        }
    }

}

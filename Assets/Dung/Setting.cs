using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private RectTransform soundBtn;
    [SerializeField] private RectTransform vibraBtn;

    private IEnumerator OnOffSound()
    {
        
        if(soundBtn.anchoredPosition.x == -160)
        {
            for(int i =-160; i <=200; i+=20)
            {
                yield return new WaitForFixedUpdate();
                soundBtn.anchoredPosition = new Vector2(i, soundBtn.anchoredPosition.y);
            }
        }
        else if (soundBtn.anchoredPosition.x == 200)
        {
            for (int i = 200; i >= -160; i -= 20)
            {
                yield return new WaitForFixedUpdate();
                soundBtn.anchoredPosition = new Vector2(i, soundBtn.anchoredPosition.y);
            }
        }
        //Debug.Log(soundBtn.anchoredPosition.x);
    }

    private IEnumerator OnOffVibration()
    {

        if (vibraBtn.anchoredPosition.x == -160)
        {
            for (int i = -160; i <= 200; i += 20)
            {
                yield return new WaitForFixedUpdate();
                vibraBtn.anchoredPosition = new Vector2(i, soundBtn.anchoredPosition.y);
            }
        }
        else if (vibraBtn.anchoredPosition.x == 200)
        {
            for (int i = 200; i >= -160; i -= 20)
            {
                yield return new WaitForFixedUpdate();
                vibraBtn.anchoredPosition = new Vector2(i, soundBtn.anchoredPosition.y);
            }
        }
        //Debug.Log(soundBtn.anchoredPosition.x);
    }

    public void ClickSoundBtn()
    {
        StartCoroutine(OnOffSound());
    }

    public void ClickVibrationBtn()
    {
        StartCoroutine(OnOffVibration());
    }
}

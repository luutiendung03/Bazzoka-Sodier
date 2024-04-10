using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private RectTransform soundBtn;
    [SerializeField] private RectTransform vibraBtn;

    private IEnumerator OnOffSound()
    {
        
        if(soundBtn.anchoredPosition.x == -70)
        {
            for (int i = -70; i <= 70; i += 10)
            {
                yield return new WaitForFixedUpdate();
                soundBtn.anchoredPosition = new Vector2(i, soundBtn.anchoredPosition.y);
            }
            PlayerPersistentData.Instance.Audio = 1;
        }
        else if (soundBtn.anchoredPosition.x == 70)
        {
            for (int i = 70; i >= -70; i -= 10)
            {
                yield return new WaitForFixedUpdate();
                soundBtn.anchoredPosition = new Vector2(i, soundBtn.anchoredPosition.y);
            }
            PlayerPersistentData.Instance.Audio = 0;
        }
        //Debug.Log(soundBtn.anchoredPosition.x);
    }

    private IEnumerator OnOffVibration()
    {

        if (vibraBtn.anchoredPosition.x == -70)
        {
            for (int i = -70; i <= 70; i += 10)
            {
                yield return new WaitForFixedUpdate();
                vibraBtn.anchoredPosition = new Vector2(i, soundBtn.anchoredPosition.y);
            }
        }
        else if (vibraBtn.anchoredPosition.x == 70)
        {
            for (int i = 70; i >= -70; i -= 10)
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

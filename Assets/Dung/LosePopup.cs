using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LosePopup : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
        AudioController.Instance.PlayAudio(1);
    }

    public void Replay()
    {
        PlayerPersistentData.Instance.TimeAds++;
        //SceneManager.LoadScene(0);
        GameManager.Instance.LoadCurrentLevel();
        gameObject.SetActive(false);
    }

    public void Skip()
    {
        UnityEvent e = new UnityEvent();

        e.AddListener(() =>
        {
            PlayerPersistentData.Instance.CurrentLevel++;
            //SceneManager.LoadScene(0);
            //PlayerPersistentData.Instance.TimeAds++;
            GameManager.Instance.LoadCurrentLevel();
            gameObject.SetActive(false);
        });

        SkygoBridge.Instance.ShowRewarded(e, null);

       
    }

    public void Reload()
    {
        UnityEvent e = new UnityEvent();

        e.AddListener(() =>
        {
            GameManager.Instance.count = 3;
            gameObject.SetActive(false);
            Level.Instance.isEndGame = false;
        });

        SkygoBridge.Instance.ShowRewarded(e, null);
       
    }


}

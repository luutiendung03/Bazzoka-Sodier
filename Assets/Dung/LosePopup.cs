using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePopup : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void Skip()
    {
        PlayerPersistentData.Instance.CurrentLevel++;
        SceneManager.LoadScene(0);
    }

    public void Reload()
    {
        GameManager.Instance.count = 3;
        gameObject.SetActive(false);
        Level.Instance.isEndGame = false;
    }


}

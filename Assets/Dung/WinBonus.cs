using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WinBonus : MonoBehaviour
{
    [SerializeField] private RectTransform arrow;

    private void Start()
    {
        Show();
    }
    public void Show()
    {
        gameObject.SetActive(true);
        LuckyBonousGold();
    }

    private void LuckyBonousGold()
    {
        arrow.DORotate(new Vector3(0, 0, 23), 1,RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Yoyo);

        
    }

    public void Claim()
    {
        
        arrow.DOKill();
        Debug.Log(arrow.eulerAngles);
        if(arrow.eulerAngles.z >= 7.60f)
        {
            PlayerPersistentData.Instance.Gold += 250;
        }
        else if(arrow.eulerAngles.z >= 2.30f)
        {
            PlayerPersistentData.Instance.Gold += 250;
            PlayerPersistentData.Instance.Gold += 250;
        }
        else if (arrow.eulerAngles.z >= -2.30f)
        {
            PlayerPersistentData.Instance.Gold += 250;
            PlayerPersistentData.Instance.Gold += 250;
            PlayerPersistentData.Instance.Gold += 250;
        }
        else if (arrow.eulerAngles.z >= -7.30f)
        {
            PlayerPersistentData.Instance.Gold += 250;
            PlayerPersistentData.Instance.Gold += 250;
        }    
        else
        {
            PlayerPersistentData.Instance.Gold += 250;
        }

        AudioController.Instance.PlayAudio(3);

    }

    public void GetCoin()
    {
        AudioController.Instance.PlayAudio(3);
        PlayerPersistentData.Instance.Gold += 100;
    }

    public void NextLevel()
    {
        AudioController.Instance.PlayAudio(3);
        SceneManager.LoadScene(0);
    }

    public void WacthAds()
    {
        PlayerPersistentData.Instance.Gold += 100;
        NextLevel();
    }
}


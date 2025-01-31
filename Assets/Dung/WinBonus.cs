using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

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
        StartCoroutine(LuckyBonousGold());
        
    }

    private IEnumerator LuckyBonousGold()
    {
        arrow.eulerAngles = new Vector3(0, 0, 15);
        yield return new WaitForSeconds(1f);
        arrow.DORotate(new Vector3(0, 0, -28), 1,RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Yoyo);

        
    }

    public void Claim()
    {

        UnityEvent e = new UnityEvent();

        e.AddListener(() =>
        {
            arrow.DOKill();
            Debug.Log(arrow.eulerAngles);
            if (arrow.eulerAngles.z >= 7.60f)
            {
                PlayerPersistentData.Instance.Gold += 250;
            }
            else if (arrow.eulerAngles.z >= 2.30f)
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
        });

        SkygoBridge.Instance.ShowRewarded(e, null);

       

    }

    public void GetCoin()
    {

        UnityEvent e = new UnityEvent();

        e.AddListener(() =>
        {
            AudioController.Instance.PlayAudio(3);
            PlayerPersistentData.Instance.Gold += 100;
        });

        SkygoBridge.Instance.ShowRewarded(e, null);
        
    }

    public void NextLevel()
    {

        AudioController.Instance.PlayAudio(3);
        arrow.DOKill();
       
        GameManager.Instance.LoadCurrentLevel();
        gameObject.SetActive(false);

        //SceneManager.LoadScene(0);
    }

    public void WacthAds()
    {
        UnityEvent e = new UnityEvent();

        e.AddListener(() =>
        {
            PlayerPersistentData.Instance.Gold += 100;
            NextLevel();
        });

        SkygoBridge.Instance.ShowRewarded(e, null);
  
    }
}


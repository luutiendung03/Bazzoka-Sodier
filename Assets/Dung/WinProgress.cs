using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class WinProgress : MonoBehaviour
{
    [SerializeField] private Image progressGiftBar;
    [SerializeField] private Image[] progressMap;
    [SerializeField] private GameObject giftClaimPane;
    [SerializeField] private Sprite[] levelMaps;
    [SerializeField] private Image currentMap;
    [SerializeField] Image nextMap;
    [SerializeField] Text progressTxt;
    [SerializeField] private Image giftImg;
    [SerializeField] private Transform giftBox;
    
    private int currentProgressMap;
    private void Start()
    {
        giftBox.DOShakePosition(4f, 20);
    }

    public void Show()
    {
        AudioController.Instance.PlayAudio(5);
        PlayerPersistentData.Instance.Gold += 250;
        PlayerPersistentData.Instance.CurrentLevel++;
        PlayerPersistentData.Instance.TimeAds++;
        PlayerPersistentData.Instance.ScoreProgress(AchievementType.PassLevels, 1);
        gameObject.SetActive(true);
        ProgressMap();
        StartCoroutine(ProgressGift());
        SetGift();
    }

    private void ProgressMap()
    {
        currentProgressMap = PlayerPersistentData.Instance.CurrentLevel % 10;
        int currentMapIndex = PlayerPersistentData.Instance.CurrentLevel / 10;
        currentMap.sprite = levelMaps[currentMapIndex];
        if (currentMapIndex < levelMaps.Length)
            nextMap.sprite = levelMaps[currentMapIndex + 1];

        foreach(Image img in progressMap)
        {
            img.enabled = false;
        }

        for (int i = 0; i < currentProgressMap - 1; i++)
        {
            progressMap[i].enabled = true;
        }
    }

    private IEnumerator ProgressGift()
    {
        float progressIndex = (PlayerPersistentData.Instance.CurrentLevel - 1) % 5;
        if (progressIndex == 0)
            progressGiftBar.fillAmount = 1;
        else
            progressGiftBar.fillAmount = progressIndex / 5;

        progressTxt.text = (progressGiftBar.fillAmount * 100).ToString() + "%";

        yield return new WaitForSeconds(4f);

        if (progressGiftBar.fillAmount == 1)
            giftClaimPane.SetActive(true);
        else
            AutoClosed();
    }

    private void SetGift()
    {
        for (int i = 0; i < 33; i++)
        {
            int saveSkin = PlayerPersistentData.Instance.GetUsedItem(LoadingItem.Skin, i);
            if (saveSkin == 0)
            {
                giftImg.sprite = ResourceManager.Instance.skinImg[i];
                break;
            }
            
            
        }
        
        giftImg.SetNativeSize();
        Vector2 nativeSize = giftImg.rectTransform.sizeDelta;
        giftImg.rectTransform.sizeDelta = nativeSize * 5;
    }

    public void ClaimGift()
    {

        UnityEvent e = new UnityEvent();

        e.AddListener(() =>
        {
            AudioController.Instance.PlayAudio(4);
            for (int i = 0; i < 33; i++)
            {
                if (PlayerPersistentData.Instance.GetUsedItem(LoadingItem.Skin, i) == 0)
                {
                    PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Skin, i);
                }
                break;
            }
            AutoClosed();
        });

        SkygoBridge.Instance.ShowRewarded(e, null);
        
    }

    public void AutoClosed()
    {
        
        gameObject.SetActive(false);
        UIManager.Instance.winBonus.Show();
    }
}

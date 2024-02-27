using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinProgress : MonoBehaviour
{
    [SerializeField] private Image progressGiftBar;
    [SerializeField] private Image[] progressMap;
    [SerializeField] private GameObject giftClaimPane;
    [SerializeField] private Sprite[] levelMaps;
    [SerializeField] private Image currentMap;
    [SerializeField] Image nextMap;
    
    private int currentProgressMap;

    public void Show()
    {
        PlayerPersistentData.Instance.Gold += 100;
        PlayerPersistentData.Instance.CurrentLevel++;
        gameObject.SetActive(true);
        ProgressMap();
        ProgressGift();
    }

    private void ProgressMap()
    {
        currentProgressMap = PlayerPersistentData.Instance.CurrentLevel % 10;
        int currentMapIndex = PlayerPersistentData.Instance.CurrentLevel / 10;
        currentMap.sprite = levelMaps[currentMapIndex];
        if (currentMapIndex < levelMaps.Length)
            nextMap.sprite = levelMaps[currentMapIndex + 1];

        for (int i = 0; i < currentProgressMap - 1; i++)
        {
            progressMap[i].enabled = true;
        }
    }

    private void ProgressGift()
    {
        progressGiftBar.fillAmount = ((float)((PlayerPersistentData.Instance.CurrentLevel - 1) % 5) / 5);

        if (progressGiftBar.fillAmount == 1)
            giftClaimPane.SetActive(true);
        else
            StartCoroutine(AutoClosed());
    }

    private IEnumerator AutoClosed()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        UIManager.Instance.winBonus.Show();
    }
}

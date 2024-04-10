using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAds : Singleton<NoAds>
{
    public void BuySGold()
    {
        AudioController.Instance.PlayAudio(4);
    }
    public void BuyMGold()
    {
        PlayerPersistentData.Instance.Gold += 15000;
        AudioController.Instance.PlayAudio(3);
    }
    public void BuyLGold()
    {
        PlayerPersistentData.Instance.Gold += 15000;
        PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Skin, 27);
        PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Skin, 28);
        PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Skin, 29);
        AudioController.Instance.PlayAudio(4);
    }
}

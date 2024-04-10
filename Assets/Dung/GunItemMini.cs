using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunItemMini : GridItem
{
    GunItemInfo gunInfo;
    [SerializeField] private Image gunImg;
    [SerializeField ] private Text priceTxt;
    [SerializeField ] private GameObject buyBtn;

    public override void Buy()
    {
        if(PlayerPersistentData.Instance.Gold >= gunInfo.gold)
        {
            PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Gun, gunInfo.id);
            AudioController.Instance.PlayAudio(4);
            PlayerPersistentData.Instance.Gold -= gunInfo.gold;
            buyBtn.SetActive(false);
        }
    }

    public void Set(GunItemInfo info)
    {
        this.gunInfo = info;
        priceTxt.text = info.gold.ToString();
        gunImg.sprite = ResourceManager.Instance.gunImg[info.id];
        gunImg.SetNativeSize();
        Vector2 nativeSize = gunImg.rectTransform.sizeDelta;
        gunImg.rectTransform.sizeDelta = nativeSize * 1.2f;
    }
}

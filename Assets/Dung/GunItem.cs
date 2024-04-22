using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GunItem : GridItem
{

    GunItemInfo info;
    public int id;
    int gold;
    string name;
    int adsWatch;

    [SerializeField] private ShopTab_InfoLoad shopTab;

    [SerializeField] private Image buyBtn;
    [SerializeField] private Image ads;
    //[SerializeField] private GameObject selectedItem;
    [SerializeField] public GameObject tickV;

    [SerializeField] private Text gunName;
    [SerializeField] private Text priceTxt;
    [SerializeField] private Text adsTxt;

    

    

    public void Set(GunItemInfo gunInfo)
    {
        info = gunInfo;
        id = gunInfo.id;
        gold = gunInfo.gold;
        name = gunInfo.name;
        adsWatch = gunInfo.ads;
        gunName.text = gunInfo.name;
        priceTxt.text = gold.ToString();
        adsTxt.text = PlayerPersistentData.Instance.GetAdsItem(LoadingItem.Gun, gunInfo.id).ToString() + "/" + gunInfo.ads;
        if(PlayerPersistentData.Instance.GetUsedItem(LoadingItem.Gun, gunInfo.id) != 0)
        {
            buyBtn.gameObject.SetActive(false);
            ads.gameObject.SetActive(false);
            //selectedItem.SetActive(true);
            //buyBtn.transform.parent.gameObject.SetActive(false);

        }
        tickV.SetActive(false);
        if (id == PlayerPersistentData.Instance.GunId)
            tickV.SetActive(true);
    }    

    public void Swap()
    {
        if(PlayerPersistentData.Instance.GetUsedItem(LoadingItem.Gun, id) == 1)
        {
            PlayerPersistentData.Instance.GunId = id;
            Player.Instance.SetGun();
            SetGun.Instance.SetCurrentGun();
            GamePlay.instance.Swap();


            //if (id == PlayerPersistentData.Instance.GunId)
            //    tickV.SetActive(true);
            Debug.Log(PlayerPersistentData.Instance.GunId);
        }
        
    }

    public void WatchAds()
    {
        UnityEvent e = new UnityEvent();

        e.AddListener(() =>
        {
            Debug.Log(id);
            PlayerPersistentData.Instance.SetAdsItem(LoadingItem.Gun, info.id);
            adsTxt.text = PlayerPersistentData.Instance.GetAdsItem(LoadingItem.Gun, id).ToString() + "/" + adsWatch;
            if (PlayerPersistentData.Instance.GetAdsItem(LoadingItem.Gun, id) == adsWatch)
            {
                PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Gun, id);
                buyBtn.gameObject.SetActive(false);
                ads.gameObject.SetActive(false);
                AudioController.Instance.PlayAudio(4);
                //buyBtn.transform.parent.gameObject.SetActive(false);
                //selectedItem.SetActive(true);
            }
        });

        SkygoBridge.Instance.ShowRewarded(e, null);
       
    }

    public override void Buy()
    {
        if(PlayerPersistentData.Instance.Gold >= gold)
        {
            PlayerPersistentData.Instance.Gold -= gold;
            PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Gun, id);
            AudioController.Instance.PlayAudio(4);
            buyBtn.gameObject.SetActive(false);
            ads.gameObject.SetActive(false);
            //buyBtn.transform.parent.gameObject.SetActive(false);
            //selectedItem.SetActive(true);
        }
        else
        {
            shopTab.Load(2);
        }
        Debug.Log(gold);
    }

    public void OnUsed()
    {
        tickV.SetActive(true);
    }

    public void OnUnused()
    {
        tickV.SetActive(false);
    }
}

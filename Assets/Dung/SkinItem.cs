using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinItem : GridItem
{
    SkinItemInfo skinInfo;
    public int id;
    TypeofSkin type;
    int topic;
    int gold;
    int adsTime;

    [SerializeField] private GameObject buyBtn;
    [SerializeField] private GameObject ads;
    //[SerializeField] GameObject selected;
    [SerializeField] public GameObject tickV;
    [SerializeField] private Image skinImg;

    [SerializeField] private ShopTab_InfoLoad shopTab;
    [SerializeField] private Text priceTxt;
    [SerializeField] private Text adsTxt;

    public void Set(SkinItemInfo skinInfo)
    {
        id = skinInfo.id;
        type = skinInfo.type;
        topic = skinInfo.topic;
        gold = skinInfo.gold;
        adsTime = skinInfo.ads;

        priceTxt.text = gold.ToString();
        adsTxt.text = PlayerPersistentData.Instance.GetAdsItem(LoadingItem.Skin, skinInfo.id).ToString() + "/" + skinInfo.ads;

        if (PlayerPersistentData.Instance.GetUsedItem(LoadingItem.Skin, id) == 1)
        {
            buyBtn.SetActive(false);
            ads.SetActive(false);
            //selected.SetActive(true);
            //skinImg.rectTransform.anchoredPosition = new Vector2(0, 5.5f);
            //skinImg.rectTransform.sizeDelta = new Vector2(356, 353);

            if (id == PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Head) * 3)
                tickV.SetActive(true);
            if (id == PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Body) * 3 + 1)
                tickV.SetActive(true);
            if (id == PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Leg) * 3 + 2)
                tickV.SetActive(true);
        }

        
    }

    public void WatchAds()
    {
        UnityEvent e = new UnityEvent();

        e.AddListener(() =>
        {
            Debug.Log(id);
            PlayerPersistentData.Instance.SetAdsItem(LoadingItem.Skin, id);
            adsTxt.text = PlayerPersistentData.Instance.GetAdsItem(LoadingItem.Skin, id).ToString() + "/" + adsTime;
            if (PlayerPersistentData.Instance.GetAdsItem(LoadingItem.Skin, id) == adsTime)
            {
                AudioController.Instance.PlayAudio(4);
                PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Skin, id);
                buyBtn.gameObject.SetActive(false);
                ads.gameObject.SetActive(false);
                //buyBtn.transform.parent.gameObject.SetActive(false);
                //selectedItem.SetActive(true);
            }
        });

        SkygoBridge.Instance.ShowRewarded(e, null);
        
    }

    public void Swap()
    {
        if (PlayerPersistentData.Instance.GetUsedItem(LoadingItem.Skin, id) == 1)
        {
            PlayerPersistentData.Instance.SetMeshSkin(type, topic);
            Debug.Log(PlayerPersistentData.Instance.GetMeshSkin(type)); ;
            Player.Instance.SetSkin();
            SetSkin.Instance.SetCurrentSkin();
        }
            
        
    }
    public override void Buy()
    {
        if (PlayerPersistentData.Instance.Gold >= gold)
        {

            AudioController.Instance.PlayAudio(4);
            PlayerPersistentData.Instance.Gold -= gold;
            PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Skin, id);
            buyBtn.SetActive(false);
            ads.SetActive(false);
            //selected.SetActive(true);
            //skinImg.rectTransform.anchoredPosition = new Vector2(0, 5.5f);
            //skinImg.rectTransform.sizeDelta = new Vector2(356, 353);
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

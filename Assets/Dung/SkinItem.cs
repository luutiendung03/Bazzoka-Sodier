using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinItem : GridItem
{
    SkinItemInfo skinInfo;
    public int id;
    TypeofSkin type;
    int topic;
    int gold;

    [SerializeField] private GameObject buyBtn;
    [SerializeField] private GameObject ads;
    [SerializeField] GameObject selected;
    [SerializeField] public GameObject tickV;
    [SerializeField] private Image skinImg;

    [SerializeField] private ShopTab_InfoLoad shopTab;

    public void Set(SkinItemInfo skinInfo)
    {
        id = skinInfo.id;
        type = skinInfo.type;
        topic = skinInfo.topic;
        gold = skinInfo.gold;

        if (PlayerPersistentData.Instance.GetUsedItem(LoadingItem.Skin, id) != 0)
        {
            buyBtn.SetActive(false);
            ads.SetActive(false);
            selected.SetActive(true);
            skinImg.rectTransform.anchoredPosition = new Vector2(0, 5.5f);
            //skinImg.rectTransform.sizeDelta = new Vector2(356, 353);

            if (id == PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Head) * 3)
                tickV.SetActive(true);
            if (id == PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Body) * 3 + 1)
                tickV.SetActive(true);
            if (id == PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Leg) * 3 + 2)
                tickV.SetActive(true);
        }

        
    }

    public void Swap()
    {
        if (PlayerPersistentData.Instance.GetUsedItem(LoadingItem.Skin, id) == 1)
        {
            PlayerPersistentData.Instance.SetMeshSkin(type, topic);
            Debug.Log(PlayerPersistentData.Instance.GetMeshSkin(type)); ;
            Player.Instance.SetSkin();
        }
            
        
    }
    public override void Buy()
    {
        if (PlayerPersistentData.Instance.Gold >= gold)
        {
            PlayerPersistentData.Instance.Gold -= gold;
            PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Skin, id);
            buyBtn.SetActive(false);
            ads.SetActive(false);
            selected.SetActive(true);
            skinImg.rectTransform.anchoredPosition = new Vector2(0, 5.5f);
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

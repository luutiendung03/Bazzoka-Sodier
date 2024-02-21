using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunItem : GridItem
{

    GunItemInfo gunInfo;
    int id;
    int gold;
    [SerializeField] private ShopTab_InfoLoad shopTab;

    [SerializeField] private Image buyBtn;
    [SerializeField] private Image ads;
    [SerializeField] private GameObject selectedItem;
    [SerializeField] public GameObject tickV;

    [SerializeField] private Text gunName;
    

    

    public void Set(GunItemInfo gunInfo)
    {
        id = gunInfo.id;
        gold = gunInfo.gold;
        gunName.text = gunInfo.name;
        if(PlayerPersistentData.Instance.GetUsedItem(LoadingItem.Gun,id) != 0)
        {
            buyBtn.enabled = false;
            ads.enabled = false;
            selectedItem.SetActive(true);
            buyBtn.transform.parent.gameObject.SetActive(false);

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
            GamePlay.instance.Swap();


            //if (id == PlayerPersistentData.Instance.GunId)
            //    tickV.SetActive(true);
            Debug.Log(PlayerPersistentData.Instance.GunId);
        }
    }
    public override void Buy()
    {
        if(PlayerPersistentData.Instance.Gold >= gold)
        {
            PlayerPersistentData.Instance.Gold -= gold;
            PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Gun, id);
            buyBtn.enabled = false;
            ads.enabled = false;
            buyBtn.transform.parent.gameObject.SetActive(false);
            selectedItem.SetActive(true);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniShop : GridItemEvent
{
    [SerializeField] GunShopInfo gunInfo;

    [SerializeField] private GunItemMini gunItemPrefab;
    [SerializeField] private RectTransform shopPane;


    private void Start()
    {

        var text = Resources.Load<TextAsset>("Data/GunShopInfo");
        Debug.Log(text);
        Debug.Log(text.ToString());
        gunInfo = JsonUtility.FromJson<GunShopInfo>(text.ToString());

        Debug.Log(gunInfo);

        LoadGun(gunInfo.gunItems);
    }

    private void LoadGun(GunItemInfo[] info)
    {
        GunItemInfo gunItemInfo;
        int count = 0;
        GunItemMini curItem;

        for(int i = 0; i < info.Length; i++)
        {
            if (count == 3)
                break;

            gunItemInfo = info[i];
            if (PlayerPersistentData.Instance.GetUsedItem(LoadingItem.Gun, gunItemInfo.id) ==0)
            {
                curItem = Instantiate(gunItemPrefab, shopPane);
                count++;
                curItem.Set(gunItemInfo);
            }
        }
    }

    public override void LoadItems()
    {
        
    }

    public override T GetItemById<T>(int id)
    {
        return null;
    }

    GunItemMini _item;
    protected override bool ClickAction(PointerEventData eventData, GameObject clicked)
    {
        _item = GridItem.GetItem<GunItemMini>(clicked);
        switch (clicked.tag)
        {
            case "FirstItem":
                
                break;
            case "SecondItem":
                _item.Buy();
                AudioController.Instance.PlayAudio(6);
                break;
            case "ThirdItem":

                break;
        }

        return true;
    }

    protected override void UpAction(Transform holding)
    {
        
    }

    protected override void DownAction(Transform holding)
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunShop_GridEvent : GridItemEvent
{
    [SerializeField] GunShopInfo gunInfo;
    private GunItem currentUsed;
    //[SerializeField] private GunItem gunItemPrefab;
    //[SerializeField] private Transform horiGrid;

    private void Start()
    {
        var text = Resources.Load<TextAsset>("Data/GunShopInfo");
        Debug.Log(text);
        Debug.Log(text.ToString());
        gunInfo = JsonUtility.FromJson<GunShopInfo>(text.ToString());

        Debug.Log(gunInfo);

        //GunItemInfo gunItemInfo;
        int index;
        //GunItem curGunItem;
        int usedIndex = PlayerPersistentData.Instance.GunId;

        //for (int i = 0; i < gunInfo.gunItems.Length; i++)
        //{
        //    gunItemInfo = gunInfo.gunItems[i];
        //    curGunItem = Instantiate((GunItem)gunItemPrefab, horiGrid);
        //    curGunItem.Set(gunItemInfo);

        //    if(i == usedIndex)
        //    {
        //        currentUsed = curGunItem;
        //    }
        //}

        foreach (GunItem item in GetComponentsInChildren<GunItem>())
        {
            index = item.transform.GetSiblingIndex();

            //Debug.Log(idAtIndex);
            item.Set(gunInfo.gunItems[index]);
            //item.CheckQuestClaimed();
            currentUsed = GetComponentsInChildren<GunItem>()[usedIndex];
        }
    }
    public override T GetItemById<T>(int id)
    {
        return null;
    }

    public override void LoadItems()
    {
        
    }


    

    GunItem _item;
    protected override bool ClickAction(PointerEventData eventData, GameObject clicked)
    {
        _item = GridItem.GetItem<GunItem>(clicked);
        switch (clicked.tag)
        {
            case "FirstItem":
                if(_item != currentUsed)
                {
                    currentUsed.OnUnused();
                    currentUsed = _item;
                    currentUsed.OnUsed();
                    _item.Swap();
                }
               

                break;
            case "SecondItem":
                _item.Buy();

                foreach (GunItem item in transform.GetComponentsInChildren<GunItem>())
                    item.tickV.SetActive(false);
                break;
            case "ThirdItem":

                break;
        }

        return true;
    }

    protected override void DownAction(Transform holding)
    {
        
    }

    protected override void UpAction(Transform holding)
    {
        
    }
}

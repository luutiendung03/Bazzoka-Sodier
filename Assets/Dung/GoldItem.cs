using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldItem : GridItem
{
    GoldItemInfo goldInfo;
    int id;
    int gold;

    public void Set(GoldItemInfo goldInfo)
    {
        id = goldInfo.id;
        gold = goldInfo.gold;
    }

    public void Swap()
    {
        PlayerPersistentData.Instance.Gold += gold;
        Debug.Log(gold);
    }
    public override void Buy()
    {

    }
}

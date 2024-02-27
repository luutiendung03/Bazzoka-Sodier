using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoldShop_GridEvent : GridItemEvent
{
    [SerializeField] GoldShopInfo goldInfo;
    private void Start()
    {
        var text = Resources.Load<TextAsset>("Data/GoldShopInfo");
        Debug.Log(text);
        Debug.Log(text.ToString());
        goldInfo = JsonUtility.FromJson<GoldShopInfo>(text.ToString());

        Debug.Log(goldInfo);
        int index;
        foreach (GoldItem item in GetComponentsInChildren<GoldItem>())
        {
            index = item.transform.GetSiblingIndex();

            item.Set(goldInfo.goldItems[index]);

        }
    }
    public override T GetItemById<T>(int id)
    {
        return null;
    }

    public override void LoadItems()
    {

    }


    GoldItem _item;
    protected override bool ClickAction(PointerEventData eventData, GameObject clicked)
    {
        _item = GridItem.GetItem<GoldItem>(clicked);
        switch (clicked.tag)
        {
            case "FirstItem":
                _item.Swap();

                break;
            case "SecondItem":

                break;
        }

        return true;
    }

    protected override void DownAction(Transform holding)
    {
        holding.transform.localScale = Vector3.one * 1.5f;
    }

    protected override void UpAction(Transform holding)
    {
        holding.transform.localScale = Vector3.one;
    }
}

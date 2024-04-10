using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoldShop_GridEvent : GridItemEvent
{
    //[SerializeField] GoldShopInfo goldInfo;
    [SerializeField] private Sprite[] icons;
    [SerializeField] private Image showroom;
    private void Start()
    {
        //var text = Resources.Load<TextAsset>("Data/GoldShopInfo");
        //Debug.Log(text);
        //Debug.Log(text.ToString());
        //goldInfo = JsonUtility.FromJson<GoldShopInfo>(text.ToString());

        //Debug.Log(goldInfo);
        //int index;
        //foreach (GoldItem item in GetComponentsInChildren<GoldItem>())
        //{
        //    index = item.transform.GetSiblingIndex();

        //    item.Set(goldInfo.goldItems[index]);

        //}
    }
    public override T GetItemById<T>(int id)
    {
        return null;
    }

    public override void LoadItems()
    {

    }


    //GoldItem _item;
    protected override bool ClickAction(PointerEventData eventData, GameObject clicked)
    {
        //_item = GridItem.GetItem<GoldItem>(clicked);
        switch (clicked.tag)
        {
            case "FirstItem":
                //_item.Swap();

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

    public void BuyAds()
    {
        AudioController.Instance.PlayAudio(4);
    }
    public void BuySGold()
    {
        PlayerPersistentData.Instance.Gold += 5500;
        AudioController.Instance.PlayAudio(3);
    }
    public void BuyMGold()
    {
        PlayerPersistentData.Instance.Gold += 15000;
        AudioController.Instance.PlayAudio(3);
    }
    public void BuyLGold()
    {
        PlayerPersistentData.Instance.Gold += 30000;
        AudioController.Instance.PlayAudio(3);
    }

    public void Item1()
    {
        showroom.sprite = icons[0];
        showroom.SetNativeSize();
        Vector2 nativeSize = showroom.rectTransform.sizeDelta;
        showroom.rectTransform.sizeDelta = nativeSize * 3f;
    }

    public void Item2()
    {
        showroom.sprite = icons[1];
        showroom.SetNativeSize();
        Vector2 nativeSize = showroom.rectTransform.sizeDelta;
        showroom.rectTransform.sizeDelta = nativeSize * 3f;
    }

    public void Item3()
    {
        showroom.sprite = icons[2];
        showroom.SetNativeSize();
        Vector2 nativeSize = showroom.rectTransform.sizeDelta;
        showroom.rectTransform.sizeDelta = nativeSize * 2.5f;
    }

    public void Item4()
    {
        showroom.sprite = icons[3];
        showroom.SetNativeSize();
        Vector2 nativeSize = showroom.rectTransform.sizeDelta;
        showroom.rectTransform.sizeDelta = nativeSize * 2.5f;
    }
}

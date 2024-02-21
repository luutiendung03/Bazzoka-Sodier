using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkinShop_GridEvent : GridItemEvent
{
    [SerializeField] SkinShopInfo skinInfo;

    private SkinItem currentHeadUsed;
    private SkinItem currentBodyUsed;
    private SkinItem currentLegUsed;

    private void Start()
    {
        var text = Resources.Load<TextAsset>("Data/SkinShopInfo");
        Debug.Log(text);
        Debug.Log(text.ToString());
        skinInfo = JsonUtility.FromJson<SkinShopInfo>(text.ToString());

        Debug.Log(skinInfo);
        int index;

        int usedHeadIndex = PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Head) * 3;
        int usedBodyIndex = (PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Head) * 3) + 1;
        int usedLegIndex = (PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Head) * 3) + 1;

        foreach (SkinItem item in GetComponentsInChildren<SkinItem>())
        {
            index = item.transform.GetSiblingIndex();

            //Debug.Log(idAtIndex);
            item.Set(skinInfo.skinItems[index]);
            //item.CheckQuestClaimed();
            currentHeadUsed = GetComponentsInChildren<SkinItem>()[usedHeadIndex];
            currentBodyUsed = GetComponentsInChildren<SkinItem>()[usedBodyIndex];
            currentLegUsed = GetComponentsInChildren<SkinItem>()[usedLegIndex];
        }
    }
    public override T GetItemById<T>(int id)
    {
        return null;
    }

    public override void LoadItems()
    {

    }

    
    SkinItem _item;
    protected override bool ClickAction(PointerEventData eventData, GameObject clicked)
    {
        _item = GridItem.GetItem<SkinItem>(clicked);
        switch (clicked.tag)
        {
            case "FirstItem":
                if(_item != currentHeadUsed)
                {
                    if (_item.id % 3 == 0)
                    {
                        currentHeadUsed.OnUnused();
                        currentHeadUsed = _item;
                        currentHeadUsed.OnUsed();
                        _item.Swap();
                    }
                    else if (_item.id % 3 == 1)
                    {
                        currentBodyUsed.OnUnused();
                        currentBodyUsed = _item;
                        currentBodyUsed.OnUsed();
                        _item.Swap();
                    }
                    else if(_item.id % 3 == 2)
                    {
                        currentLegUsed.OnUnused();
                        currentLegUsed = _item;
                        currentLegUsed.OnUsed();
                        _item.Swap();
                    }
                }
                
                //_item.Swap();

                break;
            case "SecondItem":
                _item.Buy();
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

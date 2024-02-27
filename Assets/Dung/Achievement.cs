using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Achievement : GridItemEvent
{
    [SerializeField] AchievementInfo achievementInfo;
    //private AchievementItem currentUsed;
    //[SerializeField] private GunItem gunItemPrefab;
    //[SerializeField] private Transform horiGrid;

    private void Start()
    {
        var text = Resources.Load<TextAsset>("Data/AchievementInfo");
        Debug.Log(text);
        Debug.Log(text.ToString());
        achievementInfo = JsonUtility.FromJson<AchievementInfo>(text.ToString());

        Debug.Log(achievementInfo);

        //GunItemInfo gunItemInfo;
        int index;
        //GunItem curGunItem;
        //int usedIndex = PlayerPersistentData.Instance.GunId;

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

        foreach (AchievementItem item in GetComponentsInChildren<AchievementItem>())
        {
            index = item.transform.GetSiblingIndex();

            //Debug.Log(idAtIndex);
            item.Set(achievementInfo.achievementItems[index]);
            //item.CheckQuestClaimed();

        }
    }
    public override T GetItemById<T>(int id)
    {
        return null;
    }

    public override void LoadItems()
    {

    }

    AchievementItem _item;
    protected override bool ClickAction(PointerEventData eventData, GameObject clicked)
    {
        _item = GridItem.GetItem<AchievementItem>(clicked);
        switch (clicked.tag)
        {
            case "FirstItem":
               


                break;
            case "SecondItem":
               
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

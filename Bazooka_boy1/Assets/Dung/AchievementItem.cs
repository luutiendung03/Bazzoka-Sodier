using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : GridItem
{

    AchievementItemInfo achievementItemInfo;
    private int id;
    private string name;
    private int process;
    private int gold;


    [SerializeField] private GameObject claimBtn;

    [SerializeField] private GameObject unClaimBtn;

    [SerializeField] private Image progress;

    [SerializeField] private GameObject tickV;

    [SerializeField] private RectTransform achievementName;




    public void Set(AchievementItemInfo info)
    {
        id = info.id;
        name = info.name;
        gold = info.gold;
        process = info.process;
    }
    public override void Buy()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : GridItem
{

    AchievementItemInfo info;
    private int id;
    private string name;
    private int process;
    private int gold;


    [SerializeField] private GameObject claimBtn;

    [SerializeField] private GameObject unClaimBtn;

    [SerializeField] private Image progress;

    [SerializeField] private GameObject tickV;

    [SerializeField] private Text achievementName;


    [SerializeField] public int currentProgress;
    [SerializeField] public bool isClaimed;

    public bool hasDailyClaimed => isClaimed;


    public void Set(AchievementItemInfo info)
    {
        currentProgress = PlayerPersistentData.Instance.GetProgress((AchievementType)info.id);
        isClaimed = PlayerPersistentData.Instance.HasClaimedQuest((AchievementType)info.id);

        this.info = info;

        achievementName.text = info.name;
        claimBtn.GetComponentInChildren<Text>().text = info.gold.ToString();
        unClaimBtn.GetComponentInChildren<Text>().text = info.gold.ToString();

        if (isClaimed)
        {
            claimBtn.SetActive(false);
            unClaimBtn.SetActive(false);
            tickV.SetActive(true);

        }
        float curProgress = currentProgress * 1.00f / info.process;
        progress.fillAmount = curProgress;
        QuestCompleted();
    }
    public override void Buy()
    {

    }

    public void OnClaimed()
    {
        QuestClaimed();

        Debug.Log("claim");
        PlayerPersistentData.Instance.SetClaimedQuest((AchievementType)info.id, true);
        AudioController.Instance.PlayAudio(3);
        PlayerPersistentData.Instance.Gold += info.gold;
    }

    internal void QuestClaimed()
    {
        isClaimed = true;

        claimBtn.SetActive(false);
        unClaimBtn.SetActive(false);
        tickV.SetActive(true);

        transform.SetAsLastSibling();
    }

    

    

    private void QuestCompleted()
    {
        if (currentProgress >= info.process)
        {
            if (!isClaimed)
            {
                claimBtn.SetActive(true);
                unClaimBtn.SetActive(false);
                //tickV.SetActive(true);

                transform.SetAsFirstSibling();
            }

        }
        else
        {
            claimBtn.SetActive(false);
            unClaimBtn.SetActive(true);
        }

    }

    
}

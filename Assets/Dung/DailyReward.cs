using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DailyReward : MonoBehaviour
{
    [SerializeField] private DailyItem[] dailySlot;

    [SerializeField] private RectTransform claimBtn, claimx2Btn;
    private int rewardIndex;
    private Action[] rewardActions = new Action[7];

    private void Awake()
    {
        rewardActions[0] = (() => PlayerPersistentData.Instance.Gold += 200);

        rewardActions[1] = (() => PlayerPersistentData.Instance.Gold += 500);

        rewardActions[2] = (() => PlayerPersistentData.Instance.Gold += 1000);

        rewardActions[3] = (() => PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Skin, 18));

        rewardActions[4] = (() => PlayerPersistentData.Instance.Gold += 3000);

        rewardActions[5] = (() => PlayerPersistentData.Instance.Gold += 4500);

        rewardActions[6] = (() =>
        {
            PlayerPersistentData.Instance.SetUsedItem(LoadingItem.Gun, 4);
        });
    }

    public void Claim()
    {
        if (CheckClaim())
        {
            AudioController.Instance.PlayAudio(3);
            rewardActions[rewardIndex]();
        }
    }

    public void ClaimX2()
    {
        if (CheckClaim())
        {
            UnityEvent e = new UnityEvent();

            e.AddListener(() =>
            {
                AudioController.Instance.PlayAudio(3);
                rewardActions[rewardIndex]();
                rewardActions[rewardIndex]();
            });

            SkygoBridge.Instance.ShowRewarded(e, null);
           
        }
    }

    private bool CheckClaim()
    {
        if (DateTimeController.Instance.CheckRewardDaily())
        {
            PlayerPersistentData.Instance.SaveDaily(DailyChecker.DailyReward, DateTime.Now);
            PlayerPersistentData.Instance.RewardDay++;
            Show(rewardIndex, DailyClaim.Claimed);

            claimBtn.gameObject.SetActive(false);
            claimx2Btn.gameObject.SetActive(false);


            return true;
        }
        return false;
    }

    public void ShowDaily(int rewardingDay, bool hasClaim, ref bool lockDaily)
    {
        rewardIndex = rewardingDay - 1;
        for (int i = 0; i < rewardIndex; i++)
        {
            Show(i, DailyClaim.Claimed);
        }
        if (hasClaim && rewardingDay <= 7)
        {
            Show(rewardIndex, DailyClaim.Claiming);
        }
        if (rewardingDay == 7)
        {
            claimx2Btn.gameObject.SetActive(false);
        //    Vector2 tmp = claimBtn.anchoredPosition;
        //    tmp.x = 0;
        //    claimBtn.anchoredPosition = tmp;
        }

        
    }

    private void Show(int index, DailyClaim dailyClaim)
    {
        dailySlot[index].SingleShow((int)dailyClaim);
    }
}


public enum DailyClaim
{
    Claimed,
    Claiming,
    Unclaim
}
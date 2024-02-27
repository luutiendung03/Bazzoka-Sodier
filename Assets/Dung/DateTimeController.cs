using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTimeController : Singleton<DateTimeController>
{
    [SerializeField] private DailyReward dailyReward;

    public static bool lockDaily;

    // Start is called before the first frame update
    void Start()
    {
        dailyReward.ShowDaily(PlayerPersistentData.Instance.RewardDay, CheckRewardDaily(), ref lockDaily);
    }

    public bool CheckRewardDaily()
    {
        DateTime today = DateTime.Now;
        //Debug.Log(PlayerPersistentData.Instance.RewardDay); 
        if (PlayerPersistentData.Instance.RewardDay <= 7)
        {
            if (PlayerPersistentData.Instance.GetSavedDaily(DailyChecker.DailyReward).Date < today.Date)
            {

                return true;
            }
        }

        return false;
    }
}


public enum DailyChecker
{
    DailyReward,
    Spin,
}
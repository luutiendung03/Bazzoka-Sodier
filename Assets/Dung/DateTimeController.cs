using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTimeController : Singleton<DateTimeController>
{
    [SerializeField] private DailyReward dailyReward;
    [SerializeField] private int maxAdsSpinADay;

    public static bool lockDaily;
    [SerializeField] private Spin spin;

    float lastTimeFreeSpin = 0f;

    // Start is called before the first frame update
    void Start()
    {
        dailyReward.ShowDaily(PlayerPersistentData.Instance.RewardDay, CheckRewardDaily(), ref lockDaily);

        

        CheckSpinDaily();
 
    }


    public bool CheckSpinDaily()
    {
        if (PlayerPersistentData.Instance.GetSavedDaily(DailyChecker.Spin).Date < DateTime.Now.Date)
        {
            PlayerPersistentData.Instance.DailySpinTime = maxAdsSpinADay;
            return true;
            //spin.SetSpinLeftText(PlayerPersistentData.Instance.DailySpinTime);
        }
        //spin.SetSpinLeftText(PlayerPersistentData.Instance.DailySpinTime);
        //PlayerPersistentData.Instance.SaveDaily(DailyChecker.Spin, DateTime.Now);
        else
            return false;
    }

    public void SaveSpinTime()
    {
        DateTime timeNow = DateTime.Now;

        PlayerPersistentData.Instance.SaveDaily(DailyChecker.Spin, DateTime.Now);

        lastTimeFreeSpin = Time.realtimeSinceStartup;
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
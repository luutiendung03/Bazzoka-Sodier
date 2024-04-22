using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AchievementType
{
    KillEnemies,
    Shoot,
    UseGrenade,
    UseShotgun,
    UseDigger,
    UseBurst,
    UseBounce,
    UseCluster,
    UseSticky,
    UseBunker,
    UseNapalm,
    UseRubber,
    UseLaser,
    Oneshot,
    PassLevels
}


public class PlayerPersistentData : Singleton<PlayerPersistentData>
{

    private void Start()
    {
        SetUsedItem(LoadingItem.Gun, 0);
        SetUsedItem(LoadingItem.Skin, 0);
        SetUsedItem(LoadingItem.Skin, 1);
        SetUsedItem(LoadingItem.Skin, 2);

        Audio = 1;
    }

    public int TimeAds
    {
        get => PlayerPrefs.GetInt("TImeAds", 0);

        set => PlayerPrefs.SetInt("TimeAds", value);
    }

    public int RateGame
    {
        get => PlayerPrefs.GetInt("RateGame", 0);

        set => PlayerPrefs.SetInt("RateGame", value);
    }
    public int Audio
    {
        get => PlayerPrefs.GetInt("SFX", 0);

        set => PlayerPrefs.SetInt("SFX", value);
    }

    public void SetProgress(AchievementType type, int setValue)
    {
        PlayerPrefs.SetInt(type.ToString(), setValue);
    }

    public void ScoreProgress(AchievementType type, int score)
    {
        int current = GetProgress(type);
        PlayerPrefs.SetInt(type.ToString(), current + score);
    }

    public int GetProgress(AchievementType type)
    {
        return PlayerPrefs.GetInt(type.ToString(), 0);
    }

    public bool HasClaimedQuest(AchievementType type)
    {
        return PlayerPrefs.GetInt(type.ToString() + "-hasClaimed", 0) != 0;
    }

    public void SetClaimedQuest(AchievementType type, bool state)
    {
        PlayerPrefs.SetInt(type.ToString() + "-hasClaimed", state ? 1 : 0);
    }

    public int Gold
    {
        get => PlayerPrefs.GetInt("Gold", 0);

        set => PlayerPrefs.SetInt("Gold", value);
    }
    
    public int GunId
    {
        get => PlayerPrefs.GetInt("Gun Id", 0);

        set => PlayerPrefs.SetInt("Gun Id", value);
    }

    public int GetMeshSkin(TypeofSkin meshSkin)
    {
        return PlayerPrefs.GetInt(meshSkin.ToString() +  "MeshSkin", 0);
    }

    public void SetMeshSkin(TypeofSkin meshSkin,int topic)
    {
        PlayerPrefs.SetInt(meshSkin.ToString() + "MeshSkin", topic);
    }

    public int GetAdsItem(LoadingItem item, int id)
    {
        return PlayerPrefs.GetInt(item.ToString() + "ads" + id.ToString(), 0);
    }

    public void SetAdsItem(LoadingItem item, int id)
    {
        int currentValue = GetAdsItem(item, id);

        PlayerPrefs.SetInt(item.ToString() + "ads" + id.ToString(), currentValue + 1);
    }

    public int GetUsedItem(LoadingItem item, int id)
    {
        return PlayerPrefs.GetInt(item.ToString() + "used" + id.ToString(), 0);
    }

    public void SetUsedItem(LoadingItem item, int id)
    {
        PlayerPrefs.SetInt(item.ToString() + "used" + id.ToString(), 1);
    }

    public int CurrentLevel
    {
        get => PlayerPrefs.GetInt("CurrentLevel", 1);

        set => PlayerPrefs.SetInt("CurrentLevel", value);
    }

    public int RewardDay
    {
        get => PlayerPrefs.GetInt("RewardDay", 1);
        set => PlayerPrefs.SetInt("RewardDay", value);
    }

    public void SaveDaily(DailyChecker dailyChecker, DateTime savedTime)
    {
        string saveSpin = savedTime.Year + ":" + savedTime.Month + ":" + savedTime.Day + ":" + savedTime.Hour + ":" + savedTime.Minute + ":" + savedTime.Second;
        PlayerPrefs.SetString(dailyChecker.ToString() + "-SavedTime", saveSpin);
    }

    public DateTime GetSavedDaily(DailyChecker dailyChecker)
    {
        string[] splitted = PlayerPrefs.GetString(dailyChecker.ToString() + "-SavedTime", "2023:08:10:00:00:00").Split(':');
        int year = int.Parse(splitted[0]);
        int month = int.Parse(splitted[1]);
        int day = int.Parse(splitted[2]);
        int hour = int.Parse(splitted[3]);
        int minute = int.Parse(splitted[4]);
        int second = int.Parse(splitted[5]);
        return new DateTime(year, month, day, hour, minute, second);
    }

    public int DailySpinTime
    {
        get => PlayerPrefs.GetInt("DailySpinTime", 5);

        set => PlayerPrefs.SetInt("DailySpinTime", value);
    }

   
}



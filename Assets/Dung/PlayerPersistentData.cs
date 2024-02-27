using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistentData : Singleton<PlayerPersistentData>
{
    

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
}



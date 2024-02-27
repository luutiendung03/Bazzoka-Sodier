using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GunShopInfo
{
    public GunItemInfo[] gunItems;
}

[Serializable]
public class SkinShopInfo
{
    public SkinItemInfo[] skinItems;
}

[Serializable]
public class GoldShopInfo
{
    public GoldItemInfo[] goldItems;
}

[Serializable]
public class AchievementInfo
{
    public AchievementItemInfo[] achievementItems;
}

[Serializable]
public class GunItemInfo
{
    public int id;
    public string name;
    public int gold;
}

[Serializable]
public class SkinItemInfo
{
    public int id;
    public TypeofSkin type;
    public int topic;
    public int gold;
}

[Serializable]
public class GoldItemInfo
{
    public int id;
    public int gold;
}

[Serializable]
public class AchievementItemInfo
{
    public int id;
    public string name;
    public int gold;
    public int process;
}

public enum TypeofSkin
{
    Head,
    Body,
    Leg
}

public enum LoadingItem
{
    Gun,
    Skin
}

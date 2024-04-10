using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SkygoBridge : MonoBehaviour
{
    public static SkygoBridge Instance;
#if UNITY_ANDROID
    string url = "";
#elif UNITY_IOS
    string url = "itms-apps://itunes.apple.com/app/id1466381089";
#endif
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);

        //
        //InitAds();
    }

    public int CanShowAd
    {
        get
        {
            return PlayerPrefs.GetInt("CanShowAd", 1);
        }
        set
        {
            if (value == 0)
                //IronSourceBridge.instance.HiddenBanner();
            PlayerPrefs.SetInt("CanShowAd", value);
        }
    }
    public bool isHaveGDPR { get; set; }

    float lastTimeShowAd = 0;
    public float TimeShowAds
    {
        get
        {
            return PlayerPrefs.GetFloat("TimeShowAds", 45f);
        }
        set
        {
            PlayerPrefs.SetFloat("TimeShowAds", value);
        }
    }

    public bool HasInternet()
    {
        return Application.internetReachability != NetworkReachability.NotReachable;
    }
    public bool GetCoinRate
    {
        get;
        set;
    }

    public float TimeShowAOA
    {
        get
        {
            return PlayerPrefs.GetFloat("TimeShowAOA", 15f);
        }
        set
        {
            PlayerPrefs.SetFloat("TimeShowAOA", value);
        }
    }
    //[SerializeField] AdsManager ads;
    //[SerializeField] AnalyticsManager analytics;
    //[SerializeField] InAppPurchaseManager iap;
    //[SerializeField] PromotionManager promo;
    //[SerializeField] GDPRScript gdpr;
    public bool PORS;

    //public PromotionManager Crosspromotion
    //{
    //    get
    //    {
    //        return this.promo;
    //    }
    //}

    private void Start()
    {
        //#if UNITY_ANDROID
        //        url = "https://play.google.com/store/apps/details?id=" + Application.identifier;
        //#endif
        //        Application.targetFrameRate = 60;
        //        gdpr.CallGDPR();
    }

    #region ADS
    public void ShowBanner()
    {
        //if (CanShowAd == 0) return;
        //print("Show Banner");
        //IronSourceBridge.instance.ShowBanner();
    }

    public void HideBanner()
    {

    }

    public bool ShowInterstitial(UnityEvent onClose)
    {
        onClose?.Invoke();

        //    if (CanShowAd == 0)
        //    {
        //        onClose?.Invoke();
        //        return false;
        //    }
        //    if (!IronSourceBridge.instance.ShowInterAdsIron(onClose))
        //    {
        //        onClose?.Invoke();
        //    }
            return true;
    }

    public bool ShowRewarded(UnityEvent onCompleted, UnityEvent onFailed)
    {
        onCompleted?.Invoke();

        //bool isShow = IronSourceBridge.instance.ShowRewarAdsIron(onCompleted, onFailed);
        ////DonDestroyThis.instance.SetInfo("ShowRewarded: " + isShow);
        //return isShow;

        return true;
    }

    public bool ShowRewardedInterstitial(UnityEvent onSuccess, UnityEvent onFailed)
    {
        return true;
    }
    #endregion

    #region IAP
    public void PurchaseIAP(string sku, UnityEvent onSuccess)
    {
        ////if (onSuccess != null) onSuccess.Invoke();
        //iap.BuyProduct(sku, onSuccess);
    }

    public void RestorePurchase()
    {
        //iap.RestorePurchases();
    }
    #endregion

    //public TimeSpan getRemainingTime(string sku)
    //{
    //    return iap.getRemainingTime(sku);
    //    //return new TimeSpan(24, 0, 0);
    //}
    //public bool isSubscribed(string sku)
    //{
    //    return iap.isSubscribed(sku);
    //    //return true;
    //}

    //public bool isExpired(string sku)
    //{
    //    return iap.isExpired(sku);
    //    //return true;
    //}

    //public bool isCancelled(string sku)
    //{
    //    return iap.isCancelled(sku);
    //    //return true;
    //}

    #region Analytics
    public void LogEvent(string eventName)
    {
        //analytics.LogGameEvent(eventName);
    }
    #endregion


    #region GDPR
    public void OnConfirmAds()
    {
        //ConsentForm.ShowPrivacyOptionsForm((FormError showError) =>
        //{
        //    if (showError != null)
        //    {
        //        Debug.LogError("Error showing privacy options form with error: " + showError.Message);
        //    }

        //});
        //string CMPString = PlayerPrefs.GetString("IABTCF_AddtlConsent");
        //if (!string.IsNullOrEmpty(CMPString))
        //{
        //	string[] CMPSlices = CMPString.Split("~");
        //	if (CMPSlices.Length >= 2)
        //	{
        //		string version = CMPSlices[0];
        //		if (version == "2" || version == "1")
        //		{
        //			if (CMPSlices[1].Contains("2878"))
        //			{
        //				IronSource.Agent.setConsent(true);
        //			}
        //			else
        //			{
        //				IronSource.Agent.setConsent(false);
        //			}
        //		}
        //	}
        //	else
        //	{
        //		// The consent string is not recognizable.
        //		// The publishers have two options:
        //		// a) set consent to false and initialize
        //		// IronSource.setConsent(false);
        //		// b) Do not initialize IronSource SDK
        //	}
        //}
        //else
        //{
        //	// The same condition as above
        //	// The consent string is not recognizable
        //}

    }
    #endregion
    #region Config
    //public string GetConfig(string cfgName)
    //{
    //    return analytics.GetConfigData(cfgName);
    //}
    #endregion

    #region Social
    public void RateGame()
    {
        Application.OpenURL(url);
    }

    public void ShareGame()
    {

    }
    #endregion

    #region Promotion
    public void SetCrosspromotionPosition(int positionID)
    {
        //promo.SetPosition((CrossPromotionPosition)positionID);
    }

    public void ShowPromotion()
    {
        //promo.ShowPromotion();
    }

    public void HidePromotion()
    {
        //promo.HidePromotion();
    }
    #endregion
    public void CheckPackIap(string sku_iap)
    {

    }
    public void CheckCoinIap(string sku_iap)
    {
       
    }
}
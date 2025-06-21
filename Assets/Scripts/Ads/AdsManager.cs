using UnityEngine.Advertisements;
using UnityEngine;
using System;
using System.Collections;
public class AdsManager : MonoBehaviour,
    IUnityAdsLoadListener,
    IUnityAdsShowListener,
    IUnityAdsInitializationListener
{
    [Header("---------- ANDROID IDs")]
    public string ANDROID_GAME_ID;
    public string ANDROID_INTERSTITIAL_ID = "Interstitial_Android";
    public string ANDROID_REWARDED_ID = "Rewarded_Android";
    public string ANDROID_BANNER_ID = "Banner_Android";

    [Header("---------- iOS IDs")]
    public string iOS_GAME_ID;
    public string iOS_INTERSTITIAL_ID = "Interstitial_iOS";
    public string iOS_REWARDED_ID = "Rewarded_iOS";
    public string iOS_BANNER_ID = "Banner_iOS";

    private string GAME_ID;
    private string INTERSTITIAL_ID;
    private string REWARDED_ID;
    private string BANNER_ID;

    public event Action OnRewardedCompleted;

    [Header("---------- ADS STATS")]
    public bool interstitialLoaded = false;
    public bool rewardedLoaded = false;
    public bool bannerLoaded = false;

    //[Header("---------- COMPONENTS")]
    ////para o caso de não ter Ads disponivel
    ////pode ser que naquele país não tenha nenhum
    ////ou que o player está offline sem internet
    //public GameObject backfill;
    //public GameObject closeButton;
    public void ShowBanner()
    {
        Advertisement.Banner.Show(BANNER_ID, null);
    }
    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }
    public void ShowInterstitial()
    {
        if (interstitialLoaded)
        {
            //esse evento deve ser chamado para mostrar um interstitial na tela
            Advertisement.Show(INTERSTITIAL_ID, this);
        }
        else
        {
            //backfill.SetActive(true);
            //closeButton.SetActive(false);
            Invoke(nameof(ShowCloseButton), 2);
        }
    }
    public void ShowRewarded()
    {
        if (rewardedLoaded)
        {
            //esse evento deve ser chamado para mostrar um rewarded na tela
            Advertisement.Show(REWARDED_ID, this);
        }
        else
        {
            //backfill.SetActive(true);
            //closeButton.SetActive(false);
            if (OnRewardedCompleted != null) OnRewardedCompleted();
            Invoke(nameof(ShowCloseButton), 15);
        }
    }

    void ShowCloseButton()
    {
        //closeButton.SetActive(true);
    }
    void Awake()
    {
#if UNITY_ANDROID
        GAME_ID = ANDROID_GAME_ID;
        INTERSTITIAL_ID = ANDROID_INTERSTITIAL_ID;
        REWARDED_ID = ANDROID_REWARDED_ID;
        BANNER_ID = ANDROID_BANNER_ID;
#else
        GAME_ID = iOS_GAME_ID;
        INTERSTITIAL_ID = iOS_INTERSTITIAL_ID;
        REWARDED_ID = iOS_REWARDED_ID;
        BANNER_ID = iOS_BANNER_ID;
#endif
    }
void Start()
{
    DontDestroyOnLoad(this);
    if (!Advertisement.isInitialized && Advertisement.isSupported)
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Initialize(GAME_ID, false, this); // falso = modo produção real
    }
}

    public void OnInitializationComplete()
    {
        //assim que completa o start dos Ads vamos carregar um
        //pra deixar prontinho pra ser mostrado
        Debug.Log("Unity Ads Initialized");
        interstitialLoaded = false;
        rewardedLoaded = false;
        bannerLoaded = false;

        LoadInterstitial();
        LoadRewarded();

        //BannerLoadOptions options = new BannerLoadOptions
        //{
        //    loadCallback = OnBannerLoaded,
        //    errorCallback = OnBannerError
        //};

        //Advertisement.Banner.Load(BANNER_ID, options);
    }
    //void OnBannerLoaded()
    //{
    //    //toda vez que um banner for carregado
    //    //mostra automaticamente na tela
    //    //comente essa linha abaixo caso voce
    //    //queira controlar os banner manualmente
    //    Debug.Log("OnBannerLoaded: " + BANNER_ID);
    //    bannerLoaded = true;
    //    ShowBanner();
    //}
    // Carrega Interstitial manualmente
    public void LoadInterstitial()
    {
        if (!interstitialLoaded)
        {
            Debug.Log("Loading Interstitial...");
            Advertisement.Load(INTERSTITIAL_ID, this);
        }
    }

    // Carrega Rewarded manualmente
    public void LoadRewarded()
    {
        if (!rewardedLoaded)
        {
            Debug.Log("Loading Rewarded...");
            Advertisement.Load(REWARDED_ID, this);
        }
    }
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId == INTERSTITIAL_ID) interstitialLoaded = true;
        if (placementId == REWARDED_ID) rewardedLoaded = true;
        Debug.Log("OnUnityAdsAdLoaded: " + placementId);
    }
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {placementId} - {error.ToString()} - {message}");
    }
    public void OnUnityAdsShowClick(string placementId)
    {

    }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"OnUnityAdsShowComplete {placementId}:{showCompletionState}");

        if (placementId == INTERSTITIAL_ID) interstitialLoaded = false;
        if (placementId == REWARDED_ID) rewardedLoaded = false;

        Advertisement.Load(placementId, this); // carrega só o que foi exibido

        if (placementId == REWARDED_ID &&
            showCompletionState == UnityAdsShowCompletionState.COMPLETED &&
            OnRewardedCompleted != null)
        {
            OnRewardedCompleted();
        }
    }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
    }
    public void OnUnityAdsShowStart(string placementId)
    {
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdRewardedVideo : MonoBehaviour, IUnityAdsListener
{
    string placement = "rewardedVideo";


    void Start()
    {
        DontDestroyOnLoad(this);
        Advertisement.AddListener(this);
        Advertisement.Initialize("4029125", true);
    }

    public void ShowAd()
    {
        AudioListener.volume = 0;
        Advertisement.Show("rewardedVideo");
    }
  
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        AudioListener.volume = 1;
        if (showResult == ShowResult.Finished)        
            FindObjectOfType<MoveToCheckpoint>().Move();
        else if (showResult == ShowResult.Failed)
            print("ad failed");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
      
    }

    public void OnUnityAdsReady(string placementId)
    {
       
    }

    public void OnUnityAdsDidError(string message)
    {

    }
}

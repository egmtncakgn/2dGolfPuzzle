using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class sonreklam : MonoBehaviour
{
    // Ödüllü Reklam Gösterme Kodu
    private RewardBasedVideoAd rAd;

    [Header("Ayarlar")]
    public string id = "";
    public int ödülMiktar = 1;

    [Header("Atamalar")]
    public Button reklamİzle;

    void Start()
    {
        reklamİzle.interactable = false;

        rAd = RewardBasedVideoAd.Instance;

        rAd.OnAdRewarded += VideoRewarded;
        rAd.OnAdClosed += VideoClosed;
        this.Reklamİste();
    }

    private void VideoClosed(object sender, EventArgs e)
    {
        Reklamİste();
    }

    private void VideoRewarded(object sender, Reward e)
    {
        ÖdülVer();
    }

    void Reklamİste()
    {
        AdRequest istek = new AdRequest.Builder().Build();
        this.rAd.LoadAd(istek, id);
    }

    public void ReklamGöster()
    {
        this.rAd.Show();
    }

    private void ÖdülVer()
    {
    }

    void Update()
    {
        if (rAd.IsLoaded())
        {
            reklamİzle.interactable = true;
        }
        else
        {
            reklamİzle.interactable = false;
        }
    }
}

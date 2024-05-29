using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButonSlot : MonoBehaviour
{
    public Sprite[] bölümSpriteları;
    public Sprite[] stars;
    public Sprite kilit;

    public Image renderer;
    public Image skor;

    public GameObject kapalı;
    public GameObject skorObj;

    public Button bu;

    int bölümNo;

    void Awake()
    {
        renderer = GetComponent<Image>();
        bu = GetComponent<Button>();
    }

    public void BölümYükle()
    {
        SceneManager.LoadScene(3 + bölümNo);
    }

    public void SlotHazırla(int bölüm, int star, bool açıkmı, bool geçildimi)
    {
        renderer.sprite = bölümSpriteları[bölüm];
        bölümNo = bölüm;
        
        if (!açıkmı)
        {
            skorObj.SetActive(false);
            kapalı.SetActive(true);
            bu.interactable = false;
        }
        else
        {
            kapalı.SetActive(false);

            if (geçildimi)
            {
                skorObj.SetActive(true);

                skor.sprite = stars[star];
            }
            else
            {
                skorObj.SetActive(false);
            }
        }
    }
}

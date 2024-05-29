using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UI uı;
    public BölümÖzellikleri bö;
    public TopMovement tm;

    bool isTutorial = false;

    public int hareketSay, kalanDHakkı;
    public TMP_Text sayı;
    public TMP_Text kalanHak;

    public AudioClip[] clips;
    public AudioSource audioSource;

    public void Start()
    {
        if (uı == null)
            uı = GameObject.FindWithTag("UI").GetComponent<UI>();
        if (bö == null)
            bö = GameObject.FindWithTag("GameManager").GetComponent<BölümÖzellikleri>();
        if (tm == null)
            tm = GameObject.FindWithTag("Player").GetComponent<TopMovement>();

        audioSource = GetComponent<AudioSource>();

        if (!isTutorial)
            Time.timeScale = 1;

        LeveliHazırla();

        hareketSay = 0;
    }

    public void LevelPass()
    {
        int a = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 0;
        uı.Finish();
        audioSource.clip = clips[1];
        audioSource.Play();
        PlayerPrefs.SetInt("bölüm" +  (a - 2), 1);

        if (hareketSay < 4)
            PlayerPrefs.SetInt("bölümG" + (a - 3), 3);
        else if (hareketSay >= 4 && hareketSay <= 6)
            PlayerPrefs.SetInt("bölümG" + (a - 3), 2);
        else if (hareketSay >= 6 && hareketSay <= 8)
            PlayerPrefs.SetInt("bölümG" + (a - 3), 1);
        else
            PlayerPrefs.SetInt("bölümG" + (a - 3), 0);
    }

    public void Wasted()
    {
        Time.timeScale = 0;
        uı.Başaramadın();
        tm.öldü = true;
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    public void HareketEtti()
    {
        hareketSay++;
        sayı.text = hareketSay.ToString();
    }

    public void LeveliHazırla()
    {
        kalanDHakkı = bö.HakDöndür(); 
        kalanHak.text = kalanDHakkı.ToString();
    }

    public void CoinEkle()
    {
        int a = PlayerPrefs.GetInt("Coin");
        PlayerPrefs.SetInt("Coin", a + 1);
    }
}

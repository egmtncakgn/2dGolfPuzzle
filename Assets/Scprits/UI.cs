using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject başaramadınP;
    public GameObject duraklatP;
    public GameObject levelGeçildiP;
    public GameObject dokunmaHakTx;
    public GameObject canBittiP;

    [Header("Txler")]
    public TMP_Text coinTx;
    public TMP_Text canTx;

    [Header("Butonlar")]
    public GameObject duraklatB;
    public GameObject devamB;

    int a = 0;

    public void Start()
    {
        a = PlayerPrefs.GetInt("Can");

        if (a <= 0)
        {
            ReklamPanelG();
        } 
        else
            canBittiP.SetActive(false);

        başaramadınP.SetActive(false);
        duraklatP.SetActive(false);
        duraklatB.SetActive(true);
        levelGeçildiP.SetActive(false);
        dokunmaHakTx.SetActive(true);
    }

    public void Başaramadın()
    {
        başaramadınP.SetActive(true);
        duraklatB.SetActive(false);
        dokunmaHakTx.SetActive(false);
    }

    public void Finish()
    {
        levelGeçildiP.SetActive(true);
        duraklatB.SetActive(false); 
        dokunmaHakTx.SetActive(false);
    }

    public void Duraklat()
    {
        duraklatP.SetActive(true);
        duraklatB.SetActive(false);
        Time.timeScale = 0;
    }

    public void DevamEt()
    {
        duraklatP.SetActive(false);
        duraklatB.SetActive(true);
        Time.timeScale = 1;
    }
    
    public void LevelGeçildi()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TekrarDene()
    {
        a = PlayerPrefs.GetInt("Can");
        Debug.Log("Can: " + a );
        if (a < 0)
        {
            başaramadınP.SetActive(false);
            ReklamPanelG();
        }
        else
        {
            PlayerPrefs.SetInt("Can", a - 1);
            Debug.Log(PlayerPrefs.GetInt("Can"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            
    }

    public void AnaMenü()
    {
        SceneManager.LoadScene(0);
    }

    public void ReklamPanelG()
    {
        GameObject.FindWithTag("Player").GetComponent<TopMovement>().durdu = true;
        canBittiP.SetActive(true);
        duraklatB.SetActive(false);
        PlayerPrefs.SetInt("Can", 0);

        devamB.SetActive(false);

        TxGüncelle();
    }

    public void LevelYükle(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void CanSatınAl()
    {
        int coinS = PlayerPrefs.GetInt("Coin");
        int canS = PlayerPrefs.GetInt("Can");

        if (coinS >= 1)
        {
            canS += 2;
            coinS--;

            PlayerPrefs.SetInt("Can", canS);
            PlayerPrefs.SetInt("Coin", coinS);

            devamB.SetActive(true);
        }

        TxGüncelle();
    }

    public void TxGüncelle()
    {
        int coinS = PlayerPrefs.GetInt("Coin");
        int canS = PlayerPrefs.GetInt("Can");

        coinTx.text = "Coin: " + coinS;
        canTx.text = "Can: " + canS;
    }
}

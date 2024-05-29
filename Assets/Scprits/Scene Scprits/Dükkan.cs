using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Dükkan : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject coinPanel;

    public GameObject[] panelList;

    [Header("Others")]
    public TMP_Text coinsTx;

    private void Start()
    {
        CoinGöster();
    }

    public void PanelDeğistir(int panelNo)
    {
        for (int i = 0; i < panelList.Length; i++)
        {
            if (i == panelNo)
                panelList[i].SetActive(true);
            else
                panelList[i].SetActive(false);
        }
    }

    public void Anamenuyukle()
    {
        SceneManager.LoadScene(0);
    }  

    public void CoinGöster()
    {
        coinsTx.text = "Coin: " + PlayerPrefs.GetInt("Coin");
    }
}

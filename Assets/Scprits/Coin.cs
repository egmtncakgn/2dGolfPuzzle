using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Coin : MonoBehaviour
{
    public GameManager gm;

    void Start()
    {
        if (gm == null)
            gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        if (PlayerPrefs.HasKey("CoinB" + SceneManager.GetActiveScene().buildIndex)) 
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            gm.CoinEkle();
            PlayerPrefs.SetInt("CoinB" + SceneManager.GetActiveScene().buildIndex, 0);
            Debug.Log("Coin eklendi, Coins: " + PlayerPrefs.GetInt("Coin"));
            Destroy(gameObject);
        }
            
    }
}

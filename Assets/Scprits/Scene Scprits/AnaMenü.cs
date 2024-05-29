using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Sonradan kaldır
using UnityEditor;

public class AnaMenü : MonoBehaviour
{

    private void Start()
    {
        if (!PlayerPrefs.HasKey("İlkAçılış"))
        {
            PlayerPrefs.SetInt("İlkAçılış", 5);

            PlayerPrefs.SetInt("Can",PlayerPrefs.GetInt("İlkAçılış"));
            PlayerPrefs.SetInt("maxCan",PlayerPrefs.GetInt("İlkAçılış") + 2);
            PlayerPrefs.SetInt("Coin", 0);
        }
    }
    public void Oyna()
    {   
        SceneManager.LoadScene(2);
    }

    public void Dükkan()
    {   
        SceneManager.LoadScene(1);
    }

    public void Çık()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        
    }
}

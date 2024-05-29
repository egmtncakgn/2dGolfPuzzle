using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanManager : MonoBehaviour
{
    [Header("Başlangıç Değişkenleri")]
    public int başlangıçCanı = 5;


    public int can, maxCan;
    public GameObject text;
    public TMP_Text tx;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("CanManager") != null)
        {
            Destroy(this.gameObject);
        }

        text = GameObject.FindGameObjectWithTag("canDisp");

        FirstControl();
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if(text != null)
        {
            tx = text.GetComponent<TMP_Text>();
            tx .text = "Can: " + can.ToString();
            
        }
    }

    protected void FirstControl()
    {
        if(!PlayerPrefs.HasKey("İlkAçılış"))
        {
            PlayerPrefs.SetInt("İlkAçılış", başlangıçCanı);
            
            can = başlangıçCanı;
            maxCan = başlangıçCanı + 2;
        }
        else
        {
            can = PlayerPrefs.GetInt("CanKayıt");
        }
    }

    public void CanEkle(int canD)
    {
        can =+ canD;
    }

    public void CanSil()
    {
        can--;
    }

    public void DurumuKaydet()
    {
        PlayerPrefs.SetInt("CanKayıt",can);

        DurumYenile();
    }

    public void OnApplicationQuit()
    {
        DurumuKaydet();
    }

    public void DurumYenile()
    {
        can = PlayerPrefs.GetInt("CanKayıt");

        GöstergeYenile();
    }

    public void GöstergeYenile()
    {
        if(text != null)
        {
            tx = text.GetComponent<TMP_Text>();
            tx .text = "Can: " + can.ToString();
            
        }
    }
}

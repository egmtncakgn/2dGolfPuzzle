using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BölümYükle : MonoBehaviour
{
    public GameObject bölümSlot;
    int bölNo = 0;

    void Start()
    {
        if(!PlayerPrefs.HasKey("bölüm0"))
        {
            PlayerPrefs.SetInt("bölüm0", 0);
        }

        BölümleriKontrolEt();
    }

    public void BölümleriKontrolEt()
    {
        int bölümSay = SceneManager.sceneCountInBuildSettings;

        for (int i = 3; i < bölümSay; i++)
        {
            BölümOluştur(bölNo);
            bölNo++;
        }
    }

    public void BölümOluştur(int bölümNumarası)
    {        
        bölümSlot = Instantiate(bölümSlot, this.transform);

        if(PlayerPrefs.HasKey("bölüm" + bölümNumarası.ToString()))
        {            
            if(PlayerPrefs.HasKey("bölümG" + bölümNumarası.ToString()))
            {
                int a = PlayerPrefs.GetInt("bölümG" + bölümNumarası.ToString());
                bölümSlot.GetComponent<ButonSlot>().SlotHazırla(bölümNumarası, a, true, true);
            }
            else
            {
                bölümSlot.GetComponent<ButonSlot>().SlotHazırla(bölümNumarası, 0, true, false);
            }
        }
        else
        {
            bölümSlot.GetComponent<ButonSlot>().SlotHazırla(bölümNumarası, 0, false, false);
        }  
    }
}

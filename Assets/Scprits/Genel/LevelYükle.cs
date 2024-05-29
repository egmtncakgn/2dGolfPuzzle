using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelYükle : MonoBehaviour
{
    public void LevelAç(int a)
    {
        SceneManager.LoadScene(a);
    }
}

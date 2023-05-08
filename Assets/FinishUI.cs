using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    public Image Star1, Star2, Star3;
    public GameObject Panel;

    private void Awake()
    {
        Panel.SetActive(false);
    }
    public void ReciveData(int s1, int s2, int s3)
    {
        Panel.SetActive(true);
        Star1.fillAmount = s1;
        Star2.fillAmount = s2;
        Star3.fillAmount = s3;
        SaveData(s1 + s2 + s3);
    }
    public void SaveData(int sa)
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, sa);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

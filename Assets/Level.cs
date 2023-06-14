using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Image Star1, Star2, Star3;
    public Image Close;
    public Color HasStar, HasntStar;
    public bool isComplete;
    public TextMeshProUGUI LevelText;
    public int CurrentLevel;
    public void Initialize(bool star1,bool star2,bool star3, bool complete,int level)
    {
        Star1.color = star1 ? HasStar : HasntStar;
        Star2.color = star2 ? HasStar : HasntStar;
        Star3.color = star3 ? HasStar : HasntStar;
        isComplete = complete;
        Close.gameObject.SetActive(!isComplete);
        LevelText.text = level.ToString();
        CurrentLevel = level;
    }
    public void RunLevel()
    {
        if (isComplete)
        {
            SceneManager.LoadScene($"Level{CurrentLevel}");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public List<LevelFiller> Chapters;
    public GameObject MainMenu;
    public void SelectLevel2Chapter(int chapter)
    {
        MainMenu.SetActive(false);
        Chapters[chapter].gameObject.SetActive(true);
        Chapters[chapter].Initialize();
    }
    public void ReturnToMainMenuFromChapter(int chapter)
    {
        MainMenu.SetActive(true);
        Chapters[chapter].gameObject.SetActive(false);
    }
}

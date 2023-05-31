using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFiller : MonoBehaviour
{
    public List<Level> Levels;

    public void Initialize()
    {
        for (int i = 1; i < Levels.Count+1; i++) {
            bool star1, star2, star3, isComplete;
            if (PlayerPrefs.HasKey($"Level{i}"))
            {
                int starAmount = PlayerPrefs.GetInt($"Level{i}");
                star1 = starAmount >= 1;
                star2 = starAmount >= 2;
                star3 = starAmount == 3;
                isComplete = true;
                Levels[i - 1].Initialize(star1, star2, star3, isComplete, i);
            }
            else
            {
                Levels[i - 1].Initialize(false, false, false, false, i);
            }
        }
    }
}

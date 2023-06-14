using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFiller : MonoBehaviour
{
    public List<Level> Levels;

    public void Initialize()
    {
        bool isComplete = true;
        for (int i = 1; i < Levels.Count+1; i++) {
            bool star1, star2, star3;
            if (PlayerPrefs.HasKey($"Level{i}"))
            {
                int starAmount = PlayerPrefs.GetInt($"Level{i}");
                star1 = starAmount >= 1;
                star2 = starAmount >= 2;
                star3 = starAmount == 3;
                if (starAmount > 0)
                {
                    Levels[i - 1].Initialize(star1, star2, star3, true, i);
                }
                else
                {
                    Levels[i - 1].Initialize(star1, star2, star3, isComplete, i);
                }
                isComplete = starAmount>=1;
            }
            else
            {
                Levels[i - 1].Initialize(false, false, false, isComplete, i);
                isComplete = false;
            }
        }
    }
}

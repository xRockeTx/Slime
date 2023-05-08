using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rating : MonoBehaviour
{
    public TextMeshProUGUI SlimesAmountText;
    public Image Star1, Star2, Star3;
    public int Amount;
    public int Star1Amount, Star2Amount, Star3Amount;
    public GameObject Panel;

    public FinishUI Finish;

    public void Awake()
    {
        Panel.SetActive(true);
        Amount = 0;
        UpdateSlimesAmount(0);
    }
    public void UpdateSlimesAmount(int amount)
    {
        Amount += amount;
        //SlimesAmountText.text = Amount.ToString();

        if(Amount > Star1Amount)
        {
            Star1.fillAmount = 1;
            if (Amount > Star1Amount+Star2Amount)
            {
                Star2.fillAmount = 1;
                if (Amount > Star1Amount+Star2Amount+ Star3Amount)
                {
                    Star3.fillAmount = 1;
                    SendInfo();
                }
                else
                {
                    Star3.fillAmount = (float)(Amount - Star1Amount - Star2Amount) / (float)(Star3Amount);
                }
            }
            else
            {
                Star2.fillAmount = (float)(Amount- Star1Amount) / (float)(Star2Amount);
                Star3.fillAmount = 0;
            }
        }
        else
        {
            Star1.fillAmount = (float)Amount/ (float)Star1Amount;
            Star2.fillAmount = 0;
            Star3.fillAmount = 0;
        }
    }
    public void SendInfo()
    {
        Panel.SetActive(false);
        Finish.ReciveData(Amount / Star1Amount, 
            Amount / (Star1Amount + Star2Amount),
            Amount / (Star1Amount + Star2Amount + Star3Amount));
    }
}
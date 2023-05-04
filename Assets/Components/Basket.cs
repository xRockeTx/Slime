using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public Rating Rating;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Rating.UpdateSlimesAmount(1);   
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Rating.UpdateSlimesAmount(-1);
    }
}

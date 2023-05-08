using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public Rating Rating;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Rating.UpdateSlimesAmount(1);   
    }
}

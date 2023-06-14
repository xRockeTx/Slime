using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractive : MonoBehaviour
{
    public Rigidbody2D Body;

    public void Awake()
    {
        Body = gameObject.GetComponent<Rigidbody2D>();
    }
}

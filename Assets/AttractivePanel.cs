using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttractivePanel : MonoBehaviour
{
    public Attract Cannons;
    public Attract Magnetic;
    public bool isMagnetic = false;
    public delegate void Attract();
    public static AttractivePanel instance;
    public void Awake()
    {
        instance = this;
    }
    public void Click()
    {
        if (isMagnetic)
        {
            Magnetic();
        }
        else
        {
            Cannons();
        }
    }
}

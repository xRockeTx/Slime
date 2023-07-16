using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttractivePanel : MonoBehaviour
{
    public List<Attract> Attracts;
    public Attract Magnetic;
    public bool isMagnetic = false;
    public delegate void Attract();
    public static AttractivePanel instance;
    public void Awake()
    {
        instance = this;
        Attracts = new List<Attract>();
    }
    public void Click()
    {
        if (isMagnetic)
        {
            Magnetic();
        }
        else
        {
            foreach(Attract attract in Attracts)
            {
                attract();
            }
        }
    }
}

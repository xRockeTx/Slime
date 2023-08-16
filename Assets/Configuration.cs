using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Configuration", menuName ="new Configuration")]
public class Configuration : ScriptableObject
{
    public static Configuration configuration;
    public List<Slime> Slimes;
}

public enum SlimeType
{
    Basic,
    Destroyer,
    Explosive,
    Magnetic
}


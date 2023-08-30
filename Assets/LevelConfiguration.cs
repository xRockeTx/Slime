using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfiguration : MonoBehaviour
{
    public static LevelConfiguration instance;
    [HideInInspector] public int SlimesAmount;
    public List<SlimeType> SlimeTypes;
    [HideInInspector] public List<Slime> Slimes;

    public void Awake()
    {
        instance = this;
        Slimes = new List<Slime>();
        Configuration configuration = Resources.Load<Configuration>("Configuration");
        for(int i=0;i<SlimeTypes.Count;i++)
        {
            for(int s = 0; s < configuration.Slimes.Count; s++)
            {
                if (SlimeTypes[i] == configuration.Slimes[s].SlimeType)
                {
                    Slimes.Add(configuration.Slimes[s]);
                }
            }
        }
    }

}

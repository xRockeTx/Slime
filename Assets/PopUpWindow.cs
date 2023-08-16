using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpWindow : MonoBehaviour
{
    private Cannon[] Cannons;
    public List<GameObject> Selects;
    public GameObject button;
    public void Initialize()
    {
        Cannons = (Cannon[])FindObjectsOfTypeAll(typeof(Cannon));
        foreach (Cannon cannon in Cannons)
        {
            cannon.CurrentSlime = LevelConfiguration.instance.Slimes[0].gameObject;
        }
        int slimeCount = LevelConfiguration.instance.Slimes.Count;
        if (slimeCount == 1)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
            for (int i = 0; i < Selects.Count; i++)
            {
                if (i < slimeCount)
                {
                    Selects[i].SetActive(true);
                }
                else
                {
                    Selects[i].SetActive(false);
                }
            }
        }
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Select(int id)
    {
        foreach (Cannon cannon in Cannons)
        {
            cannon.CurrentSlime = LevelConfiguration.instance.Slimes[id].gameObject;
        }
        Close();
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}

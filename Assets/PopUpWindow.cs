using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpWindow : MonoBehaviour
{
    public List<GameObject> Slimes;
    public List<Cannon> Cannons;
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Select(int id)
    {
        foreach (Cannon cannon in Cannons)
        {
            cannon.CurrentSlime = Slimes[id];
        }
        Close();
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}

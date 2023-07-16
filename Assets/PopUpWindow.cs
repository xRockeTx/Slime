using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpWindow : MonoBehaviour
{
    public List<GameObject> Slimes;
    private Cannon[] Cannons;
    public void Initialize()
    {
        Cannons = (Cannon[])FindObjectsOfTypeAll(typeof(Cannon));
        foreach (Cannon cannon in Cannons)
        {
            cannon.CurrentSlime = Slimes[0];
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
            cannon.CurrentSlime = Slimes[id];
        }
        Close();
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}

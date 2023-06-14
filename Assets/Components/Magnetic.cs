using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    private Rigidbody2D Body;
    public List<Attractive> Attractives;
    public float Radius;
    public int Force;
    public Cannon Cannon;

    public void Initialize()
    {
        Body = gameObject.GetComponent<Rigidbody2D>();
        Cannon.canShoot = false;
        AttractivePanel.instance.Magnetic = Activate; 
        AttractivePanel.instance.isMagnetic = true;
    }
    public void Activate()
    {
        Body.bodyType = RigidbodyType2D.Static;
        Collider2D[] bodies = Physics2D.OverlapCircleAll(transform.position, Radius);
        Attractives = new List<Attractive>();
        for(int i = 0; i < bodies.Length; i++)
        {
            if (bodies[i].TryGetComponent<Attractive>(out Attractive attractive))
            {
                attractive.Body.bodyType = RigidbodyType2D.Dynamic;
                attractive.Body.AddForce((transform.position-attractive.gameObject.transform.position)*Force);
            }
        }
        Cannon.canShoot = true;
        AttractivePanel.instance.isMagnetic = false;
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private bool isDestructive=false, isExplosive = false;
    private Destructive DestructiveComponent;
    private Explosive ExplosiveComponent;

    private void Awake()
    {
        if (gameObject.TryGetComponent<Destructive>(out Destructive destructive))
        {
            DestructiveComponent = destructive;
            isDestructive = true;
        }
        if (gameObject.TryGetComponent<Explosive>(out Explosive explosive))
        {
            ExplosiveComponent = explosive;
            isExplosive = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isAlive = true;
        if (collision.gameObject.TryGetComponent<KillingObstacle>(out KillingObstacle obstacle))
        {
            isAlive = false;
        }
        Collider2D[] colliders = new Collider2D[0];
        if (isExplosive && isDestructive)
        {
            // какие то эффекты
            colliders = Physics2D.OverlapCircleAll(transform.position, ExplosiveComponent.Range);
            
        }
        else if(isDestructive)
        {
            colliders = new Collider2D[1] { collision };
        }

        if (isDestructive)
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.TryGetComponent<Breakable>(out Breakable breakable))
                {
                    Destroy(breakable.gameObject);
                }
            }
        }
        if (!isAlive)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isAlive = true;
        Collider2D[] colliders = new Collider2D[0];
        if (isExplosive && isDestructive)
        {
            // какие то эффекты
            colliders = Physics2D.OverlapCircleAll(transform.position, ExplosiveComponent.Range);

        }
        else if (isDestructive)
        {
            colliders = new Collider2D[1] { collision.collider };
        }

        if (isDestructive)
        {
            isAlive = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.TryGetComponent<Breakable>(out Breakable breakable))
                {
                    Destroy(breakable.gameObject);
                }
            }
        }
        if (!isAlive)
        {
            Destroy(gameObject);
        }

    }
}

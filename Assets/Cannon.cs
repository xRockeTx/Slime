using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Following Following;
    private bool isFollow=false;
    public GameObject Slime,SuperSlime;
    public float Force=10f,Firerate=.4f;
    private float currentFirerent=0;

    private void Awake()
    {
        if(gameObject.TryGetComponent<Following>(out Following followingComponent))
        {
            isFollow = transform;
            Following = followingComponent;
        }
    }

    private void Update()
    {
        if(currentFirerent<Firerate)
        {
            currentFirerent += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Mouse0)&&currentFirerent >= Firerate)
        {
            currentFirerent = 0;
            Shoot(Slime);
        }
        else if (Input.GetKey(KeyCode.Mouse1) && currentFirerent >= Firerate)
        {
            currentFirerent = 0;
            Shoot(SuperSlime);
        }
    }
    private void Shoot(GameObject shootObject)
    {
        Vector2 direction;
        if (isFollow)
        {
            direction = Following.Direction;
        }
        else
        {
            direction = transform.up;
        }

        GameObject gameObject = Instantiate(shootObject);
        gameObject.transform.position = transform.position;
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction*Force);
    }
}

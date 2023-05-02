using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{    
    [Tooltip("Скорость перемещения")]
    public float MoveSpeed=2;

    public List<Transform> Points;
    private int ToID=1;

    private void Awake()
    {
        ToID = 0;
    }

    private void Update()
    {
        transform.position += (-transform.position + Points[ToID].position).normalized * Time.deltaTime * MoveSpeed;

        if (Vector3.Distance(transform.position, Points[ToID].position) < .3f)
        {
            ToID= (ToID + 1) % Points.Count;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    public Vector2 Direction;
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        transform.up = Direction;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    public float RotationSpeed = 10f;
    [Range(-1, 1)]
    public int Side=-1;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * RotationSpeed * Side));
    }
}

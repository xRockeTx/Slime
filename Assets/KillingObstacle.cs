using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Slime>(out Slime slime))
        {
            Destroy(other.gameObject);
        }
    }
}

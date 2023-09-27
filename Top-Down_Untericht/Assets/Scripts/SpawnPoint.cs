using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float radius = 1;
    
    public bool IsFreeToSpawn()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.zero);
        if (hit.collider == null)
            return true;
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

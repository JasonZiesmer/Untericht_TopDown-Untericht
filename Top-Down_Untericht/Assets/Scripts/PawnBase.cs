using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnBase : MonoBehaviour
{
    private Vector2 lookDirection;
    
    public Vector2 GetPosition()        // access to player pawn's position
    {
        return (Vector2)transform.position;
    }

    public void SetLookDirection(Vector2 newDirection)
    {
        newDirection.Normalize();
        lookDirection = newDirection;
    }

    public Vector2 GetLookDirection()
    {
        return lookDirection;
    }
}

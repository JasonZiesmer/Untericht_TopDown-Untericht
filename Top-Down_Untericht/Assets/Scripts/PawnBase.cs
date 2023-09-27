using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnBase : MonoBehaviour
{
    public Vector2 GetPosition()        // access to player pawn's position
    {
        return (Vector2)transform.position;
    }
}

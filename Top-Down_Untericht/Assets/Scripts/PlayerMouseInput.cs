using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseInput : MonoBehaviour
{
    [SerializeField] private Pawn pawn;
    
    private void Update()
    {
        if (Input.GetMouseButton(0))        // left mouse click
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);   // converts pixel to ScreenToWorld position
            pawn.MoveToPosition(mouseWorldPosition);
        }

        if (Input.GetMouseButton(1))        // right mouse click
        {
            pawn.CancelMovement();
        }
    }
}

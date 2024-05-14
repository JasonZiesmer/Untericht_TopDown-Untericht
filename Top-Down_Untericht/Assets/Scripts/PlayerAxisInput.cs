using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxisInput : MonoBehaviour
{
    [SerializeField] private PhysicsPawn Pawn;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Inventory inventory;
    

    private Vector2 moveDirection;

    private void Awake()
    {
        //equippedWeapon.Initialize(Pawn);
        GameState.SetState(GameState.State.InGame);
        PlayerManager.playerPawn = Pawn;
        PlayerManager.playerInventory = inventory;
        inventory.pawn = Pawn;
        Debug.Log("Player was initialized");
    }

    private void Update()
    {
        if (Pawn == null)
        {
            GameState.SetState(GameState.State.GameOver);
            enabled = false;
        }
        
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        moveDirection.Normalize();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pawnToMouse = mousePosition - Pawn.GetPosition();
        Pawn.SetLookDirection(pawnToMouse);

      Weapon equippedWeapon = inventory.GetActiveWeapon();
      if (equippedWeapon != null)
      {
          if (Input.GetMouseButtonDown(0))
          {
              equippedWeapon.StartAttacking();
          }

          if (Input.GetMouseButton(0))
          {
              equippedWeapon.StopAttacking();
          }
      }

      if (Input.mouseScrollDelta.y < 0)
      {
          inventory.SetToNextWeapon();
      }
      if (Input.mouseScrollDelta.y > 0)
      {
          inventory.SetToPreviousWeapon();
      }
    }

    private void FixedUpdate()
    {
        Pawn.MoveByForce(moveDirection * moveSpeed);
    }
}

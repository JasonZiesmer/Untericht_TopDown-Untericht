using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxisInput : MonoBehaviour
{
    [SerializeField] private PhysicsPawn Pawn;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Bullet bulletPrefab;

    private Vector2 moveDirection;

    private void Awake()
    {
        GameState.SetState(GameState.State.InGame);
        PlayerManager.playerPawn = Pawn;
    }

    private void Update()
    {
        if (Pawn == null)
        {
            GameState.SetState(GameState.State.GameOver);
            enabled = false;
            return;
        }
        
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        moveDirection.Normalize();

        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    private void FixedUpdate()
    {
        Pawn.MoveByForce(moveDirection * moveSpeed);
    }

    private void ShootBullet()
    {
        Bullet newBullet = Instantiate(bulletPrefab, Pawn.GetPosition(), Quaternion.identity);

        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        newBullet.Launch(Pawn, targetPosition);
    }
}

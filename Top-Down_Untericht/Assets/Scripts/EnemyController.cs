using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Pawn pawn;
    [SerializeField] private float distanceUntilStop = 3;
    [SerializeField] private float targetingDuration = 1;
    [SerializeField] private EnemyAnimator animator;
    [SerializeField] private Bullet bulletPrefab;

    private bool isTargetingPlayer = false;

    private void Update()
    {
        if (!isTargetingPlayer)
            UpdateMovement();
        
    }

    private void UpdateMovement()
    {
        if (Vector2.Distance(pawn.GetPosition(), PlayerManager.playerPawn.GetPosition()) < distanceUntilStop)
        {
            pawn.CancelMovement();
            TargetPlayer();
        }
        else
        {
            pawn.MoveToPosition(PlayerManager.playerPawn.GetPosition());  //asks for player pawn's position in its script and moves towards it
        }
        
    }

    private void TargetPlayer()
    {
        isTargetingPlayer = true;
        StartCoroutine(TargetAndShootThePlayerCoroutine());
    }

    private IEnumerator TargetAndShootThePlayerCoroutine()
    {
        Debug.Log("Targeting Player");
        animator.ShowTargetingAnimation(targetingDuration);
       
        yield return new WaitForSeconds(targetingDuration);

        Vector2 bulletSpawnPosition = pawn.GetPosition();
        Bullet newBullet = Instantiate(bulletPrefab, bulletSpawnPosition, quaternion.identity);
        
        newBullet.Launch(pawn, PlayerManager.playerPawn.GetPosition());
        
        isTargetingPlayer = false;
    }
}

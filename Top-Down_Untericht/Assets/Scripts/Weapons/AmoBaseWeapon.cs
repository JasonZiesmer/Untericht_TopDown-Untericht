using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmoBaseWeapon : Weapon
{
    [Header("Amo Based Weapon")]
    [SerializeField] 
    private float cooldownBetweenBullets;
    private float timeSinceLastBullet;
    private bool isAttacking;
    
    public override void StartAttacking()
    {
        isAttacking = true;
    }
    
    public override void StopAttacking()
    {
        isAttacking = false;
    }

    protected void Update()
    {
        timeSinceLastBullet += Time.deltaTime;
        
        if (!isAttacking)
            return;
        if (timeSinceLastBullet < cooldownBetweenBullets)
            return;

        timeSinceLastBullet = 0;
        ShootProjectile();
    }

    protected virtual void ShootProjectile()
    {
        
    }
}

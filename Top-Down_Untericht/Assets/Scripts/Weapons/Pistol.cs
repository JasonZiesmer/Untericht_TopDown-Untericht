using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : AmoBaseWeapon
{

    [Header("Pistol")] 
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private PhysicsPawn Pawn;
    protected override void ShootProjectile()
    {
        Bullet newBullet = Instantiate(bulletPrefab, Pawn.GetPosition(), Quaternion.identity);
        newBullet.LaunchInDirection(owner, owner.GetLookDirection());
    }
}

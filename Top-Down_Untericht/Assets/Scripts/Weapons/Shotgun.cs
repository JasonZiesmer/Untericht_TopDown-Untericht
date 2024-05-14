using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : AmoBaseWeapon
{
   [SerializeField] private Bullet bulletPrefab;
   [SerializeField] private int bulletsPerShot = 12;
   [Range(0, 1)] [SerializeField] private float spread = .25f;
   
   protected override void ShootProjectile()
   {
      for (int index = 0; index < bulletsPerShot; index++)
      {
         Vector2 bulletDierection = Random.insideUnitCircle;
         bulletDierection.Normalize();

         Vector2 targetDirection = owner.GetLookDirection();
         bulletDierection = Vector3.Slerp(bulletDierection, owner.GetLookDirection(), 1.0f - spread);

         Bullet newBullet = Instantiate(bulletPrefab, owner.GetPosition(), Quaternion.identity);
         newBullet.LaunchInDirection(owner, bulletDierection);
      }
   }
}

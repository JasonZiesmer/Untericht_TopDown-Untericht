using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Weapon newWeapon = Instantiate(weapon);
            PlayerManager.playerInventory.RegisterNewWeapon(newWeapon);
            Destroy(gameObject);
        }
    }
}

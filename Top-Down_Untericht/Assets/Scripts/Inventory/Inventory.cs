using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event Action<Weapon> OnWeaponRegistered;
    public event Action<Weapon> OnWeaponDeregistered;
    public event Action<Weapon> OnNewWeaponEquiped;
    
    public List<Weapon> weapons;
    public PhysicsPawn pawn;

    private int equippedWeaponIndex = 0;

    public void RegisterNewWeapon(Weapon weapon)
    {
        if (weapons.Contains(weapon))
            return;
        
        weapons.Add(weapon);
        weapon.transform.parent = transform;
        weapon.Initialize(pawn);
        if (OnWeaponRegistered != null)
            OnWeaponRegistered(weapon);

        if (weapons.Count == 1 && OnNewWeaponEquiped != null)
            OnNewWeaponEquiped(GetActiveWeapon());
        
        Debug.Log($"Weapon {weapon.displayName} was registered");
    }

    public void DeregisterWeapon(Weapon weapon)
    {
        if (!weapons.Contains(weapon))
            return;

        if (OnWeaponDeregistered != null)
            OnWeaponDeregistered(weapon);
        
        int index = weapons.IndexOf(weapon);
        weapons.Remove(weapon);
        
        if (index <= equippedWeaponIndex)
        {
            equippedWeaponIndex--;
            if (equippedWeaponIndex < 0)
                equippedWeaponIndex = 0;

            if (OnNewWeaponEquiped != null)
                OnNewWeaponEquiped(GetActiveWeapon());
        }
        
        Debug.Log($"Weapon {weapon.displayName} was deregistered");
    }

    public Weapon GetActiveWeapon()
    {
        if (weapons.Count == 0)
            return null;

        return weapons[equippedWeaponIndex];
    }

    public void SetToNextWeapon()
    {
        equippedWeaponIndex++;
        if (equippedWeaponIndex >= weapons.Count)
            equippedWeaponIndex = 0;
        
        if (OnNewWeaponEquiped != null)
            OnNewWeaponEquiped(GetActiveWeapon());
    }
    
    public void SetToPreviousWeapon()
    {
        equippedWeaponIndex--;
        if (equippedWeaponIndex < 0)
            equippedWeaponIndex = weapons.Count - 1;
        
        if (OnNewWeaponEquiped != null)
            OnNewWeaponEquiped(GetActiveWeapon());
    }
}

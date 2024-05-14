using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string displayName;
    protected PawnBase owner;

    public void Initialize(PawnBase newOwner)
    {
        owner = newOwner;
    }
    
    public virtual void StartAttacking()
    {
        
    }
    
    public virtual void StopAttacking()
    {
        
    }
    
    public virtual void Reload()
    {
        
    }

    private void OnEnable()
    {
        Inventory inventory = GetComponentInParent<Inventory>();
            if(inventory != null)
                inventory.RegisterNewWeapon(this);
    }

    private void OnDisable()
    {
        Inventory inventory = GetComponentInParent<Inventory>();
        if(inventory != null)
            inventory.DeregisterWeapon(this);
    }
}

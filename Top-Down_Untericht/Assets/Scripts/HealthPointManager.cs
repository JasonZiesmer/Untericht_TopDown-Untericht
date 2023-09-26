using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointManager : MonoBehaviour
{
    [SerializeField] private int maximumHitPoints;
    [SerializeField] private int currentHitPoints;

    private void Awake()
    {
        currentHitPoints = maximumHitPoints;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHitPoints -= damageAmount;
        
        if (currentHitPoints <= 0)
            Destroy(gameObject);
    }
}

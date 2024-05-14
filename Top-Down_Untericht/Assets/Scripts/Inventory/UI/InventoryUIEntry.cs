using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUIEntry : MonoBehaviour
{
    [SerializeField] private GameObject selectionMarker;
    [SerializeField] private TextMeshProUGUI text;

    public Weapon weapon;

    public void Initialize(Weapon newWeapon)
    {
        weapon = newWeapon;
        text.text = newWeapon.displayName;
        selectionMarker.SetActive(false);
    }

    public void UpdateSelectionMarker(Weapon selectedWeapon)
    {
        bool shouldBeSelected = selectedWeapon == weapon;
        selectionMarker.SetActive(shouldBeSelected);
    }
}

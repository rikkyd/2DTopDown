using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetController : MonoBehaviour
{
    public GameObject[] weaponSet;

    void Start()
    {
        deactivateAllWeapons();
        activateWeaponSet(0); 
        
    }

    void Update()
    {
        weaponUpgradeCheck();
    }

    private void deactivateAllWeapons()
    {
        foreach (GameObject go in weaponSet)
        {
            go.SetActive(false);
        }
    }

    public void activateWeaponSet(int upgradeLevel)
    {
        for (int i = 0; i < weaponSet.Length; i++)
        {
            if (i == upgradeLevel)
            {
                weaponSet[i].SetActive(true);
            }
            else
            {
                weaponSet[i].SetActive(false);
            }
        }
    }

    public void weaponUpgradeCheck() 
    {
        int upgradeLevel = GetComponents<WeaponUpgrade>().Length;

        if (upgradeLevel >= weaponSet.Length) 
        {
            upgradeLevel = weaponSet.Length - 1;
        }

        activateWeaponSet(upgradeLevel);
        fireRateUpdate();
    }

    private void fireRateUpdate() 
    {
        foreach(Weapon w in GetComponentsInChildren<Weapon>()) 
        {
            w.clearModifier();

            foreach(FireRateModifier f in GetComponents<FireRateModifier>()) 
            {
                w.addFireRateModifier(f.modifier);
    
            }
        }
    }
}
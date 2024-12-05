using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireRateModifier : MonoBehaviour 
{

    public float modifier = 0.2f;

    private List<Weapon> weapons;


    void Start() 
    {
        weapons = GetComponentsInChildren<Weapon>().ToList<Weapon>();
    }

    private void OnDestroy() 
    {
        foreach(Weapon w in weapons) 
        {
            w.removeFireRateModifier(modifier);
        }
    }

   public void addComponentToObject(GameObject go) 
   {
        go.AddComponent<FireRateModifier>();
        go.GetComponent<WeaponSetController>().weaponUpgradeCheck();
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponType _weaponType;
    public WeaponType WeaponType => _weaponType;

    void OnTriggerEnter(Collider other)
    {
        if (!_weaponType.name.Equals("Player Sword"))
            if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Environment")
                Destroy(gameObject);
    }
}

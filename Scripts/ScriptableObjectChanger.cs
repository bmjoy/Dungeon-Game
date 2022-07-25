using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectChanger : MonoBehaviour
{
    [SerializeField] ScriptableObject[] _serializableObjects;
    [SerializeField] WeaponDisplay _weaponSelection;

    void Awake() => ChangeScriptableObject();

    void ChangeScriptableObject()
    {
        if (_weaponSelection != null) _weaponSelection.DisplayWeapon1((WeaponType)_serializableObjects[0]);
        if (_weaponSelection != null) _weaponSelection.DisplayWeapon2((WeaponType)_serializableObjects[1]);
    }
}

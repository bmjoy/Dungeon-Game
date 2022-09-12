using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Objects/Weapon Type")]
public class WeaponType : ScriptableObject
{
    public enum TypeName
    {
        Bow,   
        Staff,
        Sword
    }
    public enum Range
    {
        Melee,
        Ranged
    }

    public TypeName typeName;
    public int Damage = 1;
    public Sprite WeaponModel;
    public int Price;
    public Range range;
}

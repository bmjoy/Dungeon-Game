using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Objects/Weapon Type")]
public class WeaponType : ScriptableObject
{
    public enum Types
    {
        Sword,
        Bow,
        Staff
    }

    public string Name;
    public int Damage = 1;
    public string Tag = "Attack";
    public Sprite WeaponModel;
    public int Price;
    public string Range = "Melee"; // Ranged or Melee
}

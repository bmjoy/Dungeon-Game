using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponChange : MonoBehaviour
{
    public List<GameObject> _playerWeapons = new List<GameObject>();
    public List<GameObject> _attackScripts = new List<GameObject>();

    public void ChangeWeapon(WeaponType equippedWeapon)
    {
        foreach (GameObject w in _playerWeapons)
        {
            if (w.name.Equals(equippedWeapon.Name))
                w.SetActive(true);
            else
                w.SetActive(false);
        }

        if (equippedWeapon.Name.Equals("Sword"))
        {
            _attackScripts[0].SetActive(true);
            _attackScripts[1].SetActive(false);
        }
        else if (equippedWeapon.Name.Equals("Staff"))
        {
            _attackScripts[0].SetActive(false);
            _attackScripts[1].SetActive(true);
        }

        //else if (equippedWeapon.Name.Equals(WeaponType.Types.Bow.ToString()))
        //{
        //    foreach (GameObject w in _playerWeapons)
        //    {
        //        if (w.name.Equals("Bow") || w.name.Equals("Arrow"))
        //            w.SetActive(true);
        //        else
        //            w.SetActive(false);
        //    }

        //    _attackScripts[0].SetActive(false);
        //    _attackScripts[1].SetActive(true);
        //}
    }
}

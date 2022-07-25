using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    WeaponType _weaponType1;
    WeaponType _weaponType2;

    [Header("Weapon 1")]
    [SerializeField] Text _weapon1Name;
    [SerializeField] Text _weapon1Price;
    [SerializeField] Image _weapon1Holder;

    [Header("Weapon 2")]
    [SerializeField] Text _weapon2Name;
    [SerializeField] Text _weapon2Price;
    [SerializeField] Image _weapon2Holder;

    void Awake()
    {
        Time.timeScale = 0;
    }

    public void DisplayWeapon1(WeaponType weapon)
    {
        _weaponType1 = weapon;
        _weapon1Name.text = weapon.Name;
        _weapon1Price.text = weapon.Price.ToString();
        _weapon1Holder.sprite = weapon.WeaponModel;       
    }

    public void DisplayWeapon2(WeaponType weapon)
    {
        _weaponType2 = weapon;
        _weapon2Name.text = weapon.Name;
        _weapon2Price.text = weapon.Price.ToString();
        _weapon2Holder.sprite = weapon.WeaponModel;
    }

    public void SelectWeapon1()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeaponChange>().ChangeWeapon(_weaponType1);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void SelectWeapon2()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeaponChange>().ChangeWeapon(_weaponType2);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}

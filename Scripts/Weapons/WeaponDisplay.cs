using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] WeaponType[] _weaponTypes;
    [SerializeField] Text[] _weaponNames;
    //[SerializeField] Text[] _weaponPrices;
    [SerializeField] TMP_Text [] _weaponPrices;
    [SerializeField] Image[] _weaponImages;
    [SerializeField] GameObject[] _weaponSelectButtons;

    //[SerializeField] Canvas _touchInputCanvas;

    [SerializeField] ItemCollection _playerItemCollection;

    [SerializeField] ItemType _coin;

    void Awake()
    {
        Time.timeScale = 0;

        for (int i = 0; i < _weaponTypes.Length; i++)
        {
            _weaponNames[i].text = _weaponTypes[i].typeName.ToString();
            _weaponPrices[i].text = _weaponTypes[i].Price.ToString(); ;
            _weaponImages[i].sprite = _weaponTypes[i].WeaponModel;

            if (_weaponTypes[i].Price > _playerItemCollection.Count)
            {
                _weaponSelectButtons[i].GetComponent<Button>().enabled = false;
                _weaponSelectButtons[i].GetComponent<Image>().color = new Color(0.3764706f, 0.3764706f, 0.3764706f);
            }
                
        } 
    }

    public void SelectWeapon(int weaponNumber)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeaponChange>().ChangeWeapon(_weaponTypes[weaponNumber]);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ItemCollection.Remove(_weaponTypes[weaponNumber].Price, _coin);
        Time.timeScale = 1;
        gameObject.SetActive(false);
       // _touchInputCanvas.gameObject.SetActive(true);
    }
}

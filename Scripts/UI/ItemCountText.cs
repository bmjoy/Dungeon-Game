using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCountText : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] ItemCollection _itemCollection;
    [SerializeField] ItemType _itemType;

    void Awake() => _itemCollection.Changed += UpdateText;

    void OnDestroy() => _itemCollection.Changed -= UpdateText;

    void OnEnable() => UpdateText();

    void UpdateText() => _text.SetText(_itemCollection.CountOf(_itemType).ToString());
}

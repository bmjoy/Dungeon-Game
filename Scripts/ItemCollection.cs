using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item Collection")]
public class ItemCollection : ScriptableObject
{
    public event Action Changed;

    List<ItemType> _collectedItems;

    public int Count => _collectedItems.Count;

    public void Add(Item item)
    {
        _collectedItems.Add(item.ItemType);
        Changed?.Invoke();
    }

    void OnEnable() => _collectedItems = new List<ItemType>();

    void OnDisable() => _collectedItems.Clear();

    public int CountOf(ItemType itemType) => _collectedItems.Count(t => t == itemType);
}

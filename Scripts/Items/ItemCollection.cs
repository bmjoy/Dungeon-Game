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

    public int CountOf(ItemType itemType) => _collectedItems.Count(t => t == itemType);

    void Awake() => _collectedItems = new List<ItemType>();

    public void Add(Item item)
    {
        _collectedItems.Add(item.ItemType);
        Changed?.Invoke();
    }

    public void Add(ItemType itemType)
    {
        _collectedItems.Add(itemType);
        Changed?.Invoke();
    }

    public void Remove(int amount, ItemType itemType)
    {
        for (int i = 0; i < amount; i++)
        {
            _collectedItems.Remove(itemType);
            Changed?.Invoke();
        }   
    }

    void OnDisable() => ClearCollection();

    public void ClearCollection()
    {
        _collectedItems.Clear();
    }
}



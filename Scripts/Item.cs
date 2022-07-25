using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemType _itemType;

    public ItemType ItemType => _itemType;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.ItemCollection.Add(this);
            gameObject.SetActive(false);
        }
    }

    void OnValidate() => gameObject.name = _itemType.name;
}

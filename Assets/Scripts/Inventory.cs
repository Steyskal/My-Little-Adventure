using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Inventory
{
    public int Size = 10;

    [Header("Read-only")]
    [SerializeField] private List<Item> _items = new List<Item>();

    public IReadOnlyList<Item> Items => _items.AsReadOnly(); // vrati listu samo da se moze citat

    public UnityEvent InventoryItemsChanged = new UnityEvent();

    public bool AddItem(Item item)
    {
        if(_items.Count >= Size)
        {
            Debug.Log("Inventory is full.");
            return false;
        }

        _items.Add(item);

        InventoryItemsChanged.Invoke();
        return true;
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);

        InventoryItemsChanged.Invoke();
    }
}

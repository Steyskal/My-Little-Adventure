using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public ItemButton ItemButtonPrefab;

    public GridLayoutGroup InventoryGrid;

    public PlayerController PlayerController;

    [Header("Read-only")]
    [SerializeField] private List<ItemButton> _itemButtons = new List<ItemButton>();

    private void Awake()
    {
        for (int i = 0; i < PlayerController.PlayerInventory.Size; i++)
        {
            ItemButton itemButtonClone = Instantiate(ItemButtonPrefab, InventoryGrid.transform);
            itemButtonClone.Clear();

            _itemButtons.Add(itemButtonClone);
        }

        UpdateInventoryGrid();

        PlayerController.PlayerInventory.InventoryItemsChanged.AddListener(UpdateInventoryGrid);
    }

    private void UpdateInventoryGrid()
    {
        for (int i = 0; i < PlayerController.PlayerInventory.Size; i++)
        {
            bool containsItem = i < PlayerController.PlayerInventory.Items.Count;

            if (containsItem)
                _itemButtons[i].Setup(PlayerController.PlayerInventory.Items[i]);
            else
                _itemButtons[i].Clear();
        }
    }
}

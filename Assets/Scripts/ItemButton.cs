using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Item DisplayedItem;

    [SerializeField] private Image _itemImage;
    [SerializeField] private Button _itemButton;

    public void Setup(Item setupItem)
    {
        Clear();

        DisplayedItem = setupItem;
        _itemImage.sprite = setupItem.Icon;
        _itemImage.enabled = true;

        _itemButton.onClick.AddListener(DisplayedItem.Use);
    }

    public void Clear()
    {
        DisplayedItem = null;
        _itemImage.enabled = false;

        _itemButton.onClick.RemoveAllListeners();
    }
}

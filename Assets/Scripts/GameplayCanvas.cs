using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCanvas : MonoBehaviour
{
    public GameObject InventoryPanel;

    private void Awake()
    {
        InventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            InventoryPanel.SetActive(!InventoryPanel.activeSelf);
    }
}

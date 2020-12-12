using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "My Little Adventure/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public string Description;
    public int Value;

    public void Use()
    {
        Debug.Log(Description);
    }
}

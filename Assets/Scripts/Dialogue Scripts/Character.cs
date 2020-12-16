using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "My Little Adventure/Character")]
public class Character : ScriptableObject
{
    public string Name;
    public Sprite Portrait;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "My Little Adventure/Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<Statement> Statements = new List<Statement>();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Interaction
{
    public KeyCode KeyCode;
    public string Description;
    public bool IsEnabled;
    //public Dialogue Dialogue;
    //koristi akcije ili recimo event
    public UnityEvent OnInteraction = new UnityEvent();
}

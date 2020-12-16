using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPanel : MonoBehaviour
{
    [Header("Componente References")]
    [SerializeField] private Text _keyCodeText;
    [SerializeField] private Text _descriptionText;
    
    /// <summary>
    /// Setup the interaction panel.
    /// </summary>
    /// <param name="keyCode">Key to press.</param>
    /// <param name="description">Description of the interaction.</param>
    public void Setup(KeyCode keyCode, string description)
    {
        _keyCodeText.text = keyCode.ToString();
        _descriptionText.text = description;
    }

    // method overloading
    public void Setup(Interaction interaction)
    {
        Setup(interaction.KeyCode, interaction.Description);
    }
}

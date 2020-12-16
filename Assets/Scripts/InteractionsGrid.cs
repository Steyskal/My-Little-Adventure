using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsGrid : MonoBehaviour
{
    public static InteractionsGrid Instance;

    public InteractionPanel InteractionPanelPrefab;

    private void Awake()
    {
        Instance = this;

        Hide();
    }

    public void ShowInteractions(Vector2 position, List<Interaction> interactions)
    {
        transform.position = position;

        foreach (Interaction interaction in interactions)
        {
            if (!interaction.IsEnabled)
                continue; // skoci na sljedecu iteraciju petlje, ne izvodi se ovo ispod

            InteractionPanel interactionPanelClone = Instantiate(InteractionPanelPrefab, transform);
            //interactionPanelClone.Setup(interaction.KeyCode, interaction.Description);
            interactionPanelClone.Setup(interaction);
        }

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        if (transform.childCount == 0)
            return;

        InteractionPanel[] interactionPanels = transform.GetComponentsInChildren<InteractionPanel>();

        for (int i = 0; i < interactionPanels.Length; i++)
        {
            Destroy(interactionPanels[i].gameObject);
        }
    }
}

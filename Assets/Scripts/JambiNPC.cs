using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JambiNPC : MonoBehaviour
{
    public Transform InteractionsPositionTransform;

    public List<Interaction> NPCInteractions = new List<Interaction>();

    [Header("Read-only")]
    [SerializeField] private PlayerController _playerController = null;

    private void Update()
    {
        if (_playerController == null)
            return;

        for (int i = 0; i < NPCInteractions.Count; i++)
        {
            if (Input.GetKeyUp(NPCInteractions[i].KeyCode))
            {
                Interact(i);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        _playerController = collision.GetComponent<PlayerController>();

        InteractionsGrid.Instance.ShowInteractions(InteractionsPositionTransform.position, NPCInteractions);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        _playerController = null;

        InteractionsGrid.Instance.Hide();
    }

    private void Interact(int interactionIndex)
    {
        // provjeru da li je index out of range

        if (!NPCInteractions[interactionIndex].IsEnabled)
            return;

        NPCInteractions[interactionIndex].OnInteraction.Invoke();

        if (interactionIndex == 0)
        {
            NPCInteractions[0].IsEnabled = false;
            NPCInteractions[1].IsEnabled = true;
            InteractionsGrid.Instance.Hide();
        }

        if(interactionIndex == 1)
        {
            if (_playerController.PlayerInventory.RemoveItem("Strawberry Food")) 
            {
                NPCInteractions[1].IsEnabled = false;
            }

            InteractionsGrid.Instance.Hide();
        }
    }
}

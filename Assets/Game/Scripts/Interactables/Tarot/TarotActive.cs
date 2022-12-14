using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TarotActive : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject InteractImage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerController player))
        {
            player.Interactable = this;
            InteractImage.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerController player))
        {
            InteractImage.SetActive(false);
            if(player.Interactable is TarotActive tarotActive && tarotActive == this)
            {
                player.Interactable = null;
            }

        }

    }

    public void Interact(PlayerController player)
    {
            player.TarotUI.ShowTarot();
    }
}

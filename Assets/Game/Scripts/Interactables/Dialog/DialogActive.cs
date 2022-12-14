using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogActive : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogObject dialogObject;
    [SerializeField] private GameObject InteractImage;
    [SerializeField] private bool isItem;
    [SerializeField] private int itemNumber;


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
            if(player.Interactable is DialogActive dialogActive && dialogActive == this)
            {
                player.Interactable = null;
            }

        }
    }

    public void Interact(PlayerController player)
    {
        player.DialogUI.ShowDialogue(dialogObject);
        if(isItem)
        {
            string j;
            j = "Item_" + itemNumber.ToString();
            Debug.Log(j+" Foi Interagido");
            PlayerPrefs.SetString(j,"Has");
        }
    }
}

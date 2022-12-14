using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TypewriterEffect))]
public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private PlayerInput playerInput;
    TypewriterEffect type;

    public bool IsOpen {get; private set;}

    private void Start()
    {
        playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
        type = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogObject dialogObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogObject));
    }

    private IEnumerator StepThroughDialogue(DialogObject dialogObject)
    {
        for (int i = 0; i < dialogObject.Dialogue.Length; i++)
        {
            string dialogue = dialogObject.Dialogue[i];

            yield return RunTypingEffect(dialogue);
            textLabel.text = dialogue;
            yield return null;
            yield return new WaitUntil(() => playerInput.IsInteractionButtomDown());

        }
        CloseDialogueBox();
    }

    private IEnumerator RunTypingEffect(string dialog)
    {
        type.Run(dialog, textLabel);

        while (type.isRunning)
        {
            yield return null;

            if(playerInput.IsInteractionButtomDown())
            {
                type.Stop();
            }
        }
    }

    private void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}

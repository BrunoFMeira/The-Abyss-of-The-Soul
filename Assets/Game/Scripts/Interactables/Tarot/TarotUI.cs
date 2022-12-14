using System;
using UnityEngine;

public class TarotUI : MonoBehaviour
{
    [SerializeField] private GameObject tarotBox;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private ValidateChoice validation;
    TypewriterEffect type;

    public event Action Reset;

    public bool IsOpen {get; private set;}

    private void Start()
    {
        playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
        CloseTarotBox();
    }

    public void ResetTarot()
    {
        validation.corrects = 0;
        Reset.Invoke();
    }

    public void ShowTarot()
    {
        IsOpen = true;
        tarotBox.SetActive(true);
    }

    public void CloseTarotBox()
    {
        IsOpen = false;
        tarotBox.SetActive(false);
    }
}
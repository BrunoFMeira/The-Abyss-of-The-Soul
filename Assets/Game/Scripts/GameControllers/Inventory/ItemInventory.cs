using System;
using TMPro;
using UnityEngine;


public class ItemInventory : MonoBehaviour
{
    [SerializeField] [TextArea(minLines: 4, maxLines: 10)] private String infoItem;
    [SerializeField] private TMP_Text textLabel;

    public void ShowInfo()
    {
        textLabel.text = infoItem;
    }
}

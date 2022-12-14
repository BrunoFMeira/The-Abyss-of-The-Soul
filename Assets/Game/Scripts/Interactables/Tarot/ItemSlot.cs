using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private CardInfo cardInfo;
    [SerializeField] private int orderItemSlot;
    [SerializeField] private ValidateChoice validation;
    private DragDrop item;

    public void OnDrop(UnityEngine.EventSystems.PointerEventData eventData) {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            cardInfo = eventData.pointerDrag.GetComponent<CardInfo>();
            item = eventData.pointerDrag.GetComponent<DragDrop>();

            item.IsSelected = true;
            if(cardInfo.orderCard == orderItemSlot)
            {
                validation.corrects++;
                validation.OnPut();
            }
        }
    }
}

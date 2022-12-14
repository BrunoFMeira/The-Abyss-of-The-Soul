using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasGroup))]
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TarotUI tarotUI;
    private Vector2 originalPosition;
    public bool IsSelected;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
        tarotUI.Reset += OnReset;
    }

    private void OnDestroy()
    {
        if (tarotUI != null)
        {
            tarotUI.Reset -= OnReset;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!IsSelected)
        {
            rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    public void OnPointerDown(PointerEventData eventData) {
    }

    public void OnReset()
    {
        IsSelected = false;
        rectTransform.anchoredPosition = originalPosition;
    }
}

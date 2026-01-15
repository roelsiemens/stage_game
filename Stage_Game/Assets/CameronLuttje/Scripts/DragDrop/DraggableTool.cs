using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableTool : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [Header("Tool Name")]
    public string toolName; // must match DropZone.correctTool

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Transform originalParent;
    private Vector3 startPosition;
    private bool locked = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalParent = transform.parent;
        startPosition = rectTransform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (locked) return;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (locked) return;
        rectTransform.position = Input.mousePosition;
    }

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    if (locked) return;
    //    canvasGroup.blocksRaycasts = true;
    //}

    public void ResetPosition()
    {
        rectTransform.position = startPosition;
        transform.SetParent(originalParent);
    }

    public void LockTool()
    {
        locked = true;
        canvasGroup.blocksRaycasts = false;
    }
}

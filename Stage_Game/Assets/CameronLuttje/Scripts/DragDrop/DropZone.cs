using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    [Header("Expected Tool Name")]
    public string correctTool;

    private bool filled = false;

    public bool IsFilled => filled;

    public void OnDrop(PointerEventData eventData)
    {
        if (filled) return;

        DraggableTool tool = eventData.pointerDrag.GetComponent<DraggableTool>();
        if (tool != null)
        {
            if (tool.toolName == correctTool)
            {
                // zet ding in midden van zone
                tool.transform.SetParent(transform);
                tool.transform.position = transform.position;

                filled = true;
                tool.LockTool();

                Debug.Log(correctTool + " placed correctly!");
                Object.FindAnyObjectByType<SecureSystemManager>().CheckWin();
            }
            else
            {
                // reset tool positie als niet naar goede plek
                tool.ResetPosition();
                Debug.Log("Wrong tool!");
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UIOverlapHighlight : MonoBehaviour
{
    public RawImage cl;
    public Color highlightColor = new Color(0.5f, 0.7f, 1f, 1f);

    private RawImage puzzleImage;
    private Color originalColor;
    private Color otherOriginalColor;

    void Start()
    {
        //cl = GetComponent<RawImage>();
        //puzzleImage = gameObject.GetComponentInChildren<RawImage>();
        originalColor = puzzleImage.color;
        otherOriginalColor = cl.color;
    }

    void Update()
    {
        if (IsOverlapping())
        {
            puzzleImage.color = highlightColor;
            cl.color = highlightColor;
        }
        else
        {
            puzzleImage.color = originalColor;
            cl.color = otherOriginalColor;
        }
    }

    bool IsOverlapping()
    {
        RectTransform rt1 = GetComponentInChildren<RectTransform>();
        RectTransform rt2 = cl.GetComponent<RectTransform>();
        return RectOverlaps(rt1, rt2);
    }

    bool RectOverlaps(RectTransform rt1, RectTransform rt2)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt1, rt2.position) ||
               RectTransformUtility.RectangleContainsScreenPoint(rt2, rt1.position);
    }

}

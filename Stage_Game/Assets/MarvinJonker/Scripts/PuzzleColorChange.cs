using UnityEngine;
using UnityEngine.UI;

public class UIOverlapHighlight : MonoBehaviour
{
    public RawImage otherImage;
    public Color highlightColor = new Color(0.5f, 0.7f, 1f, 1f);

    private RawImage thisImage;
    private Color originalColor;
    private Color otherOriginalColor;

    void Start()
    {
        otherImage = GetComponentInChildren<RawImage>();
        thisImage = GetComponentInChildren<RawImage>();
        originalColor = thisImage.color;
        otherOriginalColor = otherImage.color;
    }

    void Update()
    {
        if (IsOverlapping())
        {
            thisImage.color = highlightColor;
            otherImage.color = highlightColor;
        }
        else
        {
            thisImage.color = originalColor;
            otherImage.color = otherOriginalColor;
        }
    }

    bool IsOverlapping()
    {
        RectTransform rt1 = GetComponentInChildren<RectTransform>();
        RectTransform rt2 = otherImage.GetComponentInChildren<RectTransform>();
        return RectOverlaps(rt1, rt2);
    }

    bool RectOverlaps(RectTransform rt1, RectTransform rt2)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt1, rt2.position) ||
               RectTransformUtility.RectangleContainsScreenPoint(rt2, rt1.position);
    }
}

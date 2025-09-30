using UnityEngine;

public class StartBlock : MonoBehaviour
{
    public Color startColor = Color.cyan;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = startColor;
    }
}

using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Renderer tileRenderer;

    [Header("Tile properties")]
    [SerializeField] private Color offColour = Color.gray;
    [SerializeField] private Color onColour = Color.yellow;

    private bool isOn = false;
    private Material tileMaterial;

    void Start()
    {
        if (tileRenderer == null)
            tileRenderer = GetComponent<Renderer>();

        tileMaterial = tileRenderer.material;
        UpdateDisplayedState();
    }

    void UpdateDisplayedState()
    {
        if (tileMaterial != null)
        {
            tileMaterial.color = isOn ? onColour : offColour;
            Debug.Log($"Tile state updated: {(isOn ? "ON" : "OFF")}");
        }
    }

    public void Toggle()
    {
        isOn = !isOn;
        UpdateDisplayedState();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Toggle();
                }
            }
        }
    }
}

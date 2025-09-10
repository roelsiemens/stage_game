using UnityEngine;

public class LightTile : MonoBehaviour
{
    public Material onMaterial;
    public Material offMaterial;

    private Renderer rend;
    private bool isOn;
    private int gridX, gridY;
    private LightsOutManager manager;

    public bool IsOn { get { return isOn; } }

    // gebeurt wanneer grid spawnt
    public void Init(int x, int y, LightsOutManager mgr, bool startOn)
    {
        gridX = x;
        gridY = y;
        manager = mgr;
        rend = GetComponent<Renderer>();

        SetState(startOn);
    }

    private void OnMouseDown()
    {
        if (!manager.GameOver)
        {
            manager.PressAt(gridX, gridY, true, true);
        }
    }

    public void Toggle()
    {
        SetState(!isOn);
    }

    public void SetState(bool on)
    {
        isOn = on;
        if (rend != null)
        {
            rend.sharedMaterial = isOn ? onMaterial : offMaterial;
        }
    }
}

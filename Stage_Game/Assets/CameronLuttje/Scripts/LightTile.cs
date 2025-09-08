using UnityEngine;

public class LightTile : MonoBehaviour
{
    [Header("Visuals")]
    public Material onMaterial;
    public Material offMaterial;

    private Renderer _renderer;
    private bool _isOn;
    private int _x, _y;
    private LightsOutManager _manager;

    public bool IsOn => _isOn;

    public void Init(int x, int y, LightsOutManager manager, bool startOn = false)
    {
        _x = x;
        _y = y;
        _manager = manager;
        _renderer = GetComponent<Renderer>();
        SetState(startOn);
    }

    private void OnMouseDown()
    {
        // Requires a Collider on this GameObject and a Camera in the scene.
        _manager.PressAt(_x, _y, checkWin: true, countMove: true);
    }

    public void Toggle()
    {
        SetState(!_isOn);
    }

    public void SetState(bool on)
    {
        _isOn = on;
        if (_renderer == null) _renderer = GetComponent<Renderer>();
        if (_renderer != null)
            _renderer.sharedMaterial = _isOn ? onMaterial : offMaterial;
    }
}

using UnityEngine;

public class press_E_Script : MonoBehaviour
{
    public GameObject Press_E;
    private void OnTriggerEnter(Collider other)
    {
        Press_E.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Press_E.SetActive(false);
    }
}

using UnityEngine;
using TMPro;

public class SecureSystemManager : MonoBehaviour
{
    public DropZone[] dropZones;
    public TMP_Text winText;

    private void Start()
    {
        if (winText != null) winText.gameObject.SetActive(false);
    }

    public void CheckWin()
    {
        foreach (DropZone zone in dropZones)
        {
            if (!zone.IsFilled) return;
        }

        // All zones filled correctly
        if (winText != null)
        {
            winText.gameObject.SetActive(true);
            winText.text = "System Secured!";
        }

        Debug.Log("All tools placed. You win!");
    }
}

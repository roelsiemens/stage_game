using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public GameObject NpcText;
    public GameObject ConnectingText;
    public GameObject LightsOutText;
    public GameObject DroppedText;

    public bool AtNPC = false;
    public bool AtConnecting = false;
    public bool AtLightsOut = false;
    public bool AtDroppedItem = false;

    private void Update()
    {
        UiInteractions();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "FriendlyNPC":
                Debug.Log("At Friendly NPC");
                AtNPC = true;
                break;

            case "ConnectingTrigger":
                Debug.Log("At Connecting trigger");
                AtConnecting = true;
                break;

            case "LightOutTrigger":
                Debug.Log("At Lights out trigger");
                AtLightsOut = true;
                break;

            case "DroppedItem":
                Debug.Log("At Dropped item trigger");
                DroppedText.SetActive(true);
                AtDroppedItem = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "FriendlyNPC":
                Debug.Log("Left Friendly NPC");
                AtNPC = false;
                break;

            case "ConnectingTrigger":
                Debug.Log("Left Connecting trigger");
                AtConnecting = false;
                break;

            case "LightOutTrigger":
                Debug.Log("Left Lights out trigger");
                AtLightsOut = false;
                break;

            case "DroppedItem":
                Debug.Log("Left Dropped item trigger");
                NpcText.SetActive(false);
                AtDroppedItem = false;
                break;
        }
    }

    public void UiInteractions()
    {
        if (AtNPC && Input.GetKeyDown(KeyCode.E) && !NpcText.activeSelf)
        {
            NpcText.SetActive(true);
        }
        else if (AtNPC && Input.GetKeyDown(KeyCode.E) && NpcText.activeSelf)
        {
            NpcText.SetActive(false);
        }

        if (AtConnecting && Input.GetKeyDown(KeyCode.E) && !ConnectingText.activeSelf)
        {
            ConnectingText.SetActive(true);
        }
        else if (AtConnecting && Input.GetKeyDown(KeyCode.E) && ConnectingText.activeSelf)
        {
            ConnectingText.SetActive(false);
        }

        if (AtLightsOut && Input.GetKeyDown(KeyCode.E) && !LightsOutText.activeSelf)
        {
            LightsOutText.SetActive(true);
        }
        else if (AtLightsOut && Input.GetKeyDown(KeyCode.E) && LightsOutText.activeSelf)
        {
            LightsOutText.SetActive(false);
        }

        if (AtDroppedItem && Input.GetKeyDown(KeyCode.E))
        {
            DroppedText.SetActive(false);
        }
    }
}

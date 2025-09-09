using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "FriendlyNPC":
                Debug.Log("Friendly NPC");
                break;

            case "ConnectingTrigger":
                Debug.Log("Connecting trigger");
                break;

            case "LightOutTrigger":
                Debug.Log("Lights out trigger");
                break;

            case "DroppedItem":
                Debug.Log("Dropped item trigger");
                break;
        }
    }
}

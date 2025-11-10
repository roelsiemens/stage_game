using UnityEngine;

public class walk_particles : MonoBehaviour
{
    public Transform player;

    float offset = -0.92f;
    void Update()
    {
        Vector3 followpos = player.position;

        followpos.y += offset;

        transform.position = followpos;
    }
}

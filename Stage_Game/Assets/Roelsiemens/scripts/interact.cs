using UnityEngine;

public class interact : MonoBehaviour
{
    public ParticleSystem Ring;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Ring.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Ring.Stop();
        }
    }
}

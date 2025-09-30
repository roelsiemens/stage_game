using UnityEngine;

public class RotatePP : MonoBehaviour
{
    public float rotationStep = 90f;      // aantal graden per klik
    public float rotationSpeed = 180f;    // graden per seconde

    private bool isRotating = false, connected;
    private Quaternion targetRotation;    // doelrotatie

    private void Start()
    {
        // Startwaarde = huidige rotatie
        targetRotation = transform.rotation;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMouseDown()
    {
        if (!isRotating)
        {
            // Tel 90 graden op bij de huidige doelrotatie
            targetRotation *= Quaternion.Euler(0, 0, rotationStep);
            isRotating = true;
        }
    }

    void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

            // check of we het doel bereikt hebben
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
            {
                transform.rotation = targetRotation; // fix afrondingsfout
                isRotating = false; // cooldown weer vrijgeven
            }
        }
    }
}

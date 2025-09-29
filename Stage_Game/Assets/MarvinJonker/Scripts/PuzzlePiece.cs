using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public float rotationStep = 90f;      // aantal graden per klik
    public float rotationSpeed = 180f;    // graden per seconde

    private bool isRotating= false;
    private Quaternion targetRotation;    // doelrotatie

    void Start()
    {
        // Startwaarde = huidige rotatie
        targetRotation = transform.rotation;
    }

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

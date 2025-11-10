using UnityEngine;

public class ClickSpin : MonoBehaviour
{
    // The amount to rotate (90 degrees to the right)
    public float rotationAmount = 90f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("MazeBlock"))
                {
                    // Rotate the clicked object 90 degrees to the right (around Y axis)
                    hit.collider.transform.Rotate(0f, 0f, rotationAmount);
                }
            }
        }
    }
}

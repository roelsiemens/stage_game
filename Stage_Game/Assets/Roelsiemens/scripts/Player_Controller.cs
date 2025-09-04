using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterController.Move(move * Time.deltaTime *speed);
    }
}

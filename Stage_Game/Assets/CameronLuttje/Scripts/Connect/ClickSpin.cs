using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class ClickSpin : MonoBehaviour
{
    float[] rotations = { 0f, 90f, 180f, 270f };

    private void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0f, 0f, rotations[rand]);

    }

    private void OnMouseDown()
    { 
        transform.Rotate(new Vector3(0f,0f, 90f)); 
    }
}
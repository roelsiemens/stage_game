using UnityEngine;

public class TestPP : MonoBehaviour
{
    public bool connectedWithColor;

    public TestPM testManager;

    public GameObject connectedCL;

    private void Start()
    {
        connectedWithColor = false;

        testManager = GameObject.Find("testPuzzle").GetComponent<TestPM>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CL") && collision.GetComponent<TestCL>().clConnectedWithColor)
        {
            connectedWithColor = true;
            testManager.CheckConnections(connectedWithColor, collision.gameObject, gameObject);
        }
        if (collision.CompareTag("CL") && connectedWithColor)
        {
            connectedWithColor = true;
            testManager.CheckConnections(connectedWithColor, gameObject, collision.gameObject);
        }
        if (collision.CompareTag("CL") && collision.GetComponent<TestCL>().clConnectedWithColor == false)
        {
            connectedWithColor = false;
            testManager.CheckConnections(connectedWithColor, collision.gameObject, gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CL") && connectedWithColor)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            connectedWithColor = false;
        }
    }
}

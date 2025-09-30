using UnityEngine;

public class TestCL : MonoBehaviour
{
    public bool clConnectedWithColor;

    public TestPM testManager;

    public GameObject connectedPP;

    private void Start()
    {
        clConnectedWithColor = false;

        testManager = GameObject.Find("testPuzzle").GetComponent<TestPM>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puzzlepiece") && collision.GetComponent<TestPP>().connectedWithColor)
        {
            clConnectedWithColor = true;
            testManager.CheckConnections(clConnectedWithColor, collision.gameObject, gameObject);
        }
        if (collision.CompareTag("Puzzlepiece") && clConnectedWithColor)
        {
            clConnectedWithColor = true;
            testManager.CheckConnections(clConnectedWithColor, gameObject, collision.gameObject);
        }    
        if (collision.CompareTag("Puzzlepiece") && collision.GetComponent<TestPP>().connectedWithColor == false)
        {
            clConnectedWithColor = false;
            testManager.CheckConnections(clConnectedWithColor, collision.gameObject, gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Start"))
        {
            clConnectedWithColor = true;
            testManager.CheckConnections(clConnectedWithColor, collision.gameObject, gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {      
            clConnectedWithColor = false;
            testManager.CheckConnections(clConnectedWithColor, collision.gameObject, gameObject);
    }

    
}

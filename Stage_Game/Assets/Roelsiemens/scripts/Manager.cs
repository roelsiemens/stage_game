using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    public void scene_Changer(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartApp : MonoBehaviour
{
    public void RestartApplication()
    {
        SceneManager.LoadScene(0);
    }
}

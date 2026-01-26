using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartGame2()
    {
        Debug.Log("RESTART BUTTON CLICKED");
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void Nextlevel()
    {
        Debug.Log("NextLevel Button CLICKED");
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }
}

using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject container;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("klik");
            container.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void ResumeButton()
    {
        container.SetActive(false); 
        Time.timeScale = 1f;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject minUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0f; // zet de game op pauze
            minUI.SetActive(true);
        }
    }
}

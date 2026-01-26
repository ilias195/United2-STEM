using UnityEngine;

public class PlatformerBackground : MonoBehaviour
{
    [SerializeField] private float strength = 0.3f; // hoeveel ermee beweegt met de camara van de background
    private Vector3 lastCamPosition;

    private void Start()
    {
        lastCamPosition = Camera.main.transform.position;
    }

    private void LateUpdate() // latetUpdate: willen kijken wat de Chinemanchine na de update uitgevoerd,zodat de camara kan mee bewegen met de background
    {
        Vector3 difference = Camera.main.transform.position - lastCamPosition;
        transform.position += new Vector3(difference.x * strength, difference.y * strength, 0);
        lastCamPosition = Camera.main.transform.position;
    }
}

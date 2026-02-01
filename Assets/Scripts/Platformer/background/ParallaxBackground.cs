using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parrallaxEffectMultiplier; // beweegt de helft van de snelheid van de camara
    private Transform camaraTransform;
    private Vector3 lastCamaraPosition;

    private void Start()
    {
        camaraTransform = Camera.main.transform;
        lastCamaraPosition = camaraTransform.position; // zeggen waar de camara nu is
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = camaraTransform.position - lastCamaraPosition; //hoeveel heeft de camara zich bewogen sinds de vorige frame
        transform.position += new Vector3 (deltaMovement.x * parrallaxEffectMultiplier.x, deltaMovement.y * parrallaxEffectMultiplier.y);
        lastCamaraPosition = camaraTransform.position; // zeggen dit is nu de positie 
    }
}

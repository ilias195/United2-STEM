using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parrallaxEffectMultiplier; // beweegt de helft van de snelheid van de camara
    private Transform camaraTransform;
    private Vector3 lastCamaraPosition;
    private float textureUnitSizeX;
    private float textureUnitSizeY;

    [SerializeField] private bool infiniteHorizontal;
    [SerializeField] private bool infiniteVertical;

    // NIEUW (maar structuur blijft logisch)
    private Vector3 startPosition; // originele positie van object
    private Vector3 startCameraPosition; // originele camera positie

    private void Start()
    {
        camaraTransform = Camera.main.transform;
        lastCamaraPosition = camaraTransform.position; // zeggen waar de camara nu is

        startPosition = transform.position; // opslaan beginpositie
        startCameraPosition = camaraTransform.position; // opslaan begin camera positie

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        // hoeveel heeft de camara zich bewogen sinds de start
        Vector3 cameraMovement = camaraTransform.position - startCameraPosition;

        //  FIX: geen += meer (geen drift)
        transform.position = startPosition + new Vector3(
            cameraMovement.x * parrallaxEffectMultiplier.x,
            cameraMovement.y * parrallaxEffectMultiplier.y,
            0);

        lastCamaraPosition = camaraTransform.position; // zeggen dit is nu de positie 

        if (infiniteHorizontal)
        {
            if (Mathf.Abs(camaraTransform.position.x - transform.position.x) >= textureUnitSizeX)// Controleert of de camera verder is dan één sprite-breedte
            {
                float offsetPositionX = (camaraTransform.position.x - transform.position.x) % textureUnitSizeX; // Berekent hoeveel de achtergrond moet verschuiven
                transform.position = new Vector3(
                    camaraTransform.position.x + offsetPositionX,
                    transform.position.y,
                    transform.position.z);//Verplaatst de achtergrond zodat hij zich herhaalt
            }
        }

        if (infiniteVertical)
        {
            if (Mathf.Abs(camaraTransform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float offsetPositionY = (camaraTransform.position.y - transform.position.y) % textureUnitSizeY;

                transform.position = new Vector3(
                    transform.position.x,
                    camaraTransform.position.y + offsetPositionY,
                    transform.position.z);
            }
        }
    }
}

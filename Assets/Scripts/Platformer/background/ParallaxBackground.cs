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

    private void Start()
    {
        camaraTransform = Camera.main.transform;
        lastCamaraPosition = camaraTransform.position; // zeggen waar de camara nu is
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = camaraTransform.position - lastCamaraPosition; //hoeveel heeft de camara zich bewogen sinds de vorige frame
        transform.position += new Vector3 (deltaMovement.x * parrallaxEffectMultiplier.x, deltaMovement.y * parrallaxEffectMultiplier.y);
        lastCamaraPosition = camaraTransform.position; // zeggen dit is nu de positie 


        if (infiniteHorizontal)
        {
            if (Mathf.Abs(camaraTransform.position.x - transform.position.x) >= textureUnitSizeX)// Controleert of de camera verder is dan één sprite-breedte
            {
                float offsetPositionX = (camaraTransform.position.x - transform.position.x) % textureUnitSizeX; // Berekent hoeveel de achtergrond moet verschuiven
                transform.position = new Vector3(camaraTransform.position.x + offsetPositionX, transform.position.y);//Verplaatst de achtergrond zodat hij zich herhaalt

            }
        }

        if ( infiniteVertical)
        {
            if (Mathf.Abs(camaraTransform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float offsetPositionY = (camaraTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(transform.position.x, camaraTransform.position.x + offsetPositionY);

            }
        }
        
    }
}

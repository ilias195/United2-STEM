using Unity.VisualScripting;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Renderer renderer;
    [SerializeField] float _speed = 0.5f;

    private void Update()
    {
        renderer.material.mainTextureOffset += new Vector2(_speed * Time.deltaTime, 0);
    }
}

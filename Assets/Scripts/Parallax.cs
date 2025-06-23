using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Parallax Info")]
    [SerializeField] private float animationSpeed = 1f;

    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        meshRenderer.sharedMaterial.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}

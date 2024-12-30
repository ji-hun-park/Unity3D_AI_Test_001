using UnityEngine;

public class ObjectOutline : MonoBehaviour
{
    public Material outlineMaterial;  // 녹색 테두리 Material
    private Material originalMaterial; // 원래 Material
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (objectRenderer != null)
            {
                objectRenderer.material = outlineMaterial; // 테두리 Material 적용
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (objectRenderer != null)
            {
                objectRenderer.material = originalMaterial; // 원래 Material 복원
            }
        }
    }
}
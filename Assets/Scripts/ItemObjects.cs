using UnityEngine;

public class ItemObjects : MonoBehaviour
{
    public Material outlineMaterial;  // 녹색 테두리 Material
    private Material originalMaterial; // 원래 Material
    private Renderer objectRenderer;

    [SerializeField] private string ItemName;
    public string itemName {get => ItemName; set => ItemName = value;}

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }
        
        GameManager.Instance.ItemList.Add(ItemName);
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
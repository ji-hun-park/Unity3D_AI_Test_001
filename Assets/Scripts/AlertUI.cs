using UnityEngine;

public class AlertUI : MonoBehaviour
{
    [SerializeField] private string CurrentItemObject;
    public string currentItemObject{get => CurrentItemObject; set => CurrentItemObject = value;}
    
    public void OnClickYesButton()
    {
        Debug.Log("Yes");
        gameObject.SetActive(false);
    }
    
    public void OnClickNoButton()
    {
        Debug.Log("No");
        gameObject.SetActive(false);
    }
}

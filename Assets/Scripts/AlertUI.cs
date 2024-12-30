using UnityEngine;

public class AlertUI : MonoBehaviour
{
    [SerializeField] private string CurrentItemObject;
    public string currentItemObject{get => CurrentItemObject; set => CurrentItemObject = value;}
    
    public void OnClickYesButton()
    {
        Debug.Log("Yes");
        if (CurrentItemObject == GameManager.Instance.answerItem)
        {
            GameManager.Instance.clearFlag = true;
        }
        else
        {
            GameManager.Instance.failFlag = true;
        }
        gameObject.SetActive(false);
    }
    
    public void OnClickNoButton()
    {
        Debug.Log("No");
        gameObject.SetActive(false);
    }
}

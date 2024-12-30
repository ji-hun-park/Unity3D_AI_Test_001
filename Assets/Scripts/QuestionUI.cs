using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionUI : MonoBehaviour
{
    public TMP_InputField questionText; 
    private string queryText;

    private void Awake()
    {
        questionText = UIManager.Instance.FindChildByName(transform, "InputFieldTMP").GetComponent<TMP_InputField>();
    }
    
    public void OnClickSendButton()
    {
        queryText = questionText.text;
        LLMAPIManager.Instance.isCatch = false;
        LLMAPIManager.Instance.SendRequest(queryText);
        GameManager.Instance.qnaCount--;
        UIManager.Instance.npcUI.RefreshText();
        gameObject.SetActive(false);
    }
}

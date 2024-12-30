using System;
using UnityEngine;
using UnityEngine.UI;

public class NPCUI : MonoBehaviour
{
    public Text chatText;
    public Text qnaText;

    private void Awake()
    {
        chatText = UIManager.Instance.FindChildByName(transform, "ChatText").GetComponent<Text>();
        qnaText = UIManager.Instance.FindChildByName(transform, "QnaText").GetComponent<Text>();
    }

    private void OnEnable()
    {
        chatText.text = "질문할 내용이 뭔가요?";
        qnaText.text = "질문하기 / 남은 질문 수 : " + GameManager.Instance.qnaCount;
    }

    public void RefreshText()
    {
        qnaText.text = "질문하기 / 남은 질문 수 : " + GameManager.Instance.qnaCount;
        if (LLMAPIManager.Instance.isCatch)
        {
            chatText.text = LLMAPIManager.Instance.apiResponse;
        }
        else
        {
            chatText.text = "모델 응답 대기 중";
        }
    }
    
    public void OnClickBackButton()
    {
        gameObject.SetActive(false);
    }

    public void OnClickHistoryButton()
    {
        Debug.Log("OnClickHistoryButton");
    }
    
    public void OnClickQNAButton()
    {
        if (GameManager.Instance.qnaCount != 0)
        {
            UIManager.Instance.UIList[2].gameObject.SetActive(true);
        }
    }
}

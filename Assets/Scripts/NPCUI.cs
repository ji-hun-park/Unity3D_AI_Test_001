using System;
using UnityEngine;
using UnityEngine.UI;

public class NPCUI : MonoBehaviour
{
    public Text chatText;
    public Text qnaText;
    public Image profile;

    private void Awake()
    {
        chatText = UIManager.Instance.FindChildByName(transform, "ChatText").GetComponent<Text>();
        qnaText = UIManager.Instance.FindChildByName(transform, "QnaText").GetComponent<Text>();
        profile = UIManager.Instance.FindChildByName(transform, "Profile").GetComponent<Image>();
    }

    private void OnEnable()
    {
        chatText.text = "질문할 내용이 뭔가요?";
        qnaText.text = "질문하기 / 남은 질문 수 : " + GameManager.Instance.qnaCount;
        if (profile != null)
        {
            string path = "Android";
            Texture2D T2D = Resources.Load<Texture2D>(path);
            profile.sprite = Sprite.Create(T2D, new Rect(0, 0, T2D.width, T2D.height), new Vector2(0.5f, 0.5f)); 
            if (T2D != null) Debug.Log($"{T2D} loaded Successfully!");
            else Debug.Log($"Failed to load {T2D} at path : {path}");
        }
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
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void OnClickHistoryButton()
    {
        UIManager.Instance.UIList[3].gameObject.SetActive(true);
    }
    
    public void OnClickQNAButton()
    {
        if (GameManager.Instance.qnaCount != 0)
        {
            UIManager.Instance.UIList[2].gameObject.SetActive(true);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class OverUI : MonoBehaviour
{
    private Text altText;

    private void Awake()
    {
        altText = UIManager.Instance.FindChildByName(transform, "AlertText").gameObject.GetComponent<Text>();
    }

    private void OnEnable()
    {
        ChangeText();
    }

    public void ChangeText()
    {
        if (GameManager.Instance.clearFlag)
        {
            altText.text = "게임 클리어!";
        }
        else if (GameManager.Instance.failFlag)
        {
            altText.text = "게임 오버!";
        }
    }

    public void OnClickRestartButton()
    {
        Debug.Log("Game Restart");
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    
    public void OnClickEndButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

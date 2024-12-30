using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // 싱글톤 패턴 적용
    public static UIManager Instance;
    
    [SerializeField]private GameObject canvas;
    public List<RectTransform> UIList = new List<RectTransform>();
    
    [Header("Scripts")]
    public AlertUI AltUI;
    void Awake()
    {
        // Instance 존재 유무에 따라 게임 매니저 파괴 여부 정함
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 기존에 존재 안하면 이걸로 대체하고 파괴하지 않기
        }
        else
        {
            Destroy(gameObject); // 기존에 존재하면 자신파괴
        }
    }
    
    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        if (canvas != null)
        {
            FindAlertUI();
        }
    }

    private void FindAlertUI()
    {
        Transform target = FindChildByName(canvas.transform, "AlertUI");

        if (target != null)
        {
            Debug.Log("찾은 오브젝트: " + target.name);
            UIList.Add(target.GetComponent<RectTransform>());
            AltUI = target.GetComponent<AlertUI>();
        }
        else
        {
            Debug.Log("오브젝트를 찾을 수 없습니다.");
        }
    }

    Transform FindChildByName(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child;
            }

            // 재귀적으로 자식 검색
            Transform result = FindChildByName(child, name);
            if (result != null)
            {
                return result;
            }
        }
        return null; // 찾지 못했을 경우 null 반환
    }
}

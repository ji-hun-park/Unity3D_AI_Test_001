using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 패턴 적용
    public static GameManager Instance;
    
    [SerializeField] private Transform player;
    public KeyCode interactKey;

    [SerializeField] private string answerItem;
    
    [Header("Flags")]
    [SerializeField] private bool ClearFlag;
    public bool clearFlag { get => ClearFlag; set => ClearFlag = value; }
    
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
        
        interactKey = KeyCode.F;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}

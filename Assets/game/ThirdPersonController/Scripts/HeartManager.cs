using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartManager : MonoBehaviour
{
    public static int heartCount; // 現在のハート数
    public int defaultHeartCount = 3; // デフォルトの初期ハート数
    public int stage1HeartCount = 0; // Stage1 の初期ハート数
    

    private static HeartManager instance;


    void InitializeHearts()
    {
        // 現在のシーン名を取得
        string currentScene = SceneManager.GetActiveScene().name;

        // シーン名が "Stage1"or "Pre1" の場合は特別な初期値に設定
        if (currentScene == "Stage1" || currentScene == "Pre1")
        {
            heartCount = stage1HeartCount;
        }
        else
        {
            heartCount = defaultHeartCount;
        }
    }

    // シーン遷移時に初期ハート数を更新する
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeHearts();
    }

    public void HeartDamage()
    {
        heartCount--;
    }
}

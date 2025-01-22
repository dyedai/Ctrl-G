using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//public class TitleScreenManager : MonoBehaviour
//{
//    // UIを含むCanvas全体への参照
//    [SerializeField] private Canvas mainCanvas;
//    [SerializeField] private GameObject instructionPanel;
//    public static TitleScreenManager Instance { get; private set; }
//    public static float totalPlayTime = 0f;
//    private static bool isTimerRunning = false;  // staticに変更

//    [SerializeField] private Button startButton;
//    [SerializeField] private Button exitButton;
//    [SerializeField] private Button instructionButton;
//    [SerializeField] private Button backButton;

//    private void Awake()
//    {
//        if (Instance != null && Instance != this)
//        {
//            Destroy(gameObject);
//            return;
//        }
//        Instance = this;

//        // Canvas全体をDontDestroyOnLoadに設定
//        if (mainCanvas != null)
//        {
//            DontDestroyOnLoad(mainCanvas.gameObject);
//        }

//        // TitleScreenManagerもDontDestroyOnLoadに設定
//        DontDestroyOnLoad(gameObject);

//        // シーン切り替え時のイベントリスナーを追加
//        SceneManager.sceneLoaded += OnSceneLoaded;
//    }

//    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//    {
//        if (scene.name == "Title")
//        {
//            // タイトルシーンの場合はCanvasを表示
//            if (mainCanvas != null)
//            {
//                mainCanvas.gameObject.SetActive(true);
//            }
//        }
//        else
//        {
//            // タイトル以外のシーンではCanvasを非表示
//            if (mainCanvas != null)
//            {
//                mainCanvas.gameObject.SetActive(false);
//            }
//        }
//    }

//    private void Start()
//    {
//        Cursor.visible = true;
//        Cursor.lockState = CursorLockMode.None;
//    }

//    void Update()
//    {
//        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.G))
//        {
//            SceneManager.LoadScene("StageSelect");
//        }

//        if (isTimerRunning && Time.timeScale > 0)
//        {
//            totalPlayTime += Time.unscaledDeltaTime;
//        }

//        Debug.Log(totalPlayTime);
//    }

//    public static bool IsTimerRunning()
//    {
//        return isTimerRunning;
//    }

//    public static void SetTimerRunning(bool state)
//    {
//        isTimerRunning = state;
//    }

//    public void OnStartButtonPressed()
//    {
//        ResetTimer();
//        Debug.Log("スタート");
//        isTimerRunning = true;
//        Cursor.visible = false;
//        Cursor.lockState = CursorLockMode.Locked;
//        SceneManager.LoadScene("Stage1");
//    }

//    public void OnExitButtonPressed()
//    {
//        Application.Quit();
//    }

//    public void OnInstructionButtonPressed()
//    {
//        if (instructionPanel != null)
//        {
//            instructionPanel.SetActive(true);
//        }
//    }

//    public void OnBackButtonPressed()
//    {
//        if (instructionPanel != null)
//        {
//            instructionPanel.SetActive(false);
//        }
//    }

//    private void ResetTimer()
//    {
//        totalPlayTime = 0f;
//    }

//    public static void StopTimer()
//    {
//        totalPlayTime = Mathf.Round(totalPlayTime * 100f) / 100f;
//    }

//    private void OnDestroy()
//    {
//        SceneManager.sceneLoaded -= OnSceneLoaded;
//    }
//}



public class TitleScreenManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip SE;
    public AudioClip playSE;
    [SerializeField] private GameObject instructionPanel;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("StageSelect");
        }
    }

    //public void OnStartButtonPressed()
    //{
    //    audioSource.PlayOneShot(playSE);
    //    GameTimer.ResetTimer();//タイマーリセット
    //    GameTimer.StartTimer(); // タイマーを開始
    //    Debug.Log("スタート");
    //    Cursor.visible = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    //    SceneManager.LoadScene("Stage1");
    //}
    public void OnStartButtonPressed()
    {
        audioSource.PlayOneShot(playSE); // 効果音を再生
        GameTimer.ResetTimer();          // タイマーリセット
        GameTimer.StartTimer();          // タイマーを開始
        Debug.Log("スタート");
        Cursor.visible = false;          // カーソルを非表示
        Cursor.lockState = CursorLockMode.Locked; // カーソルをロック

        // コルーチンを開始してシーンロードを遅延させる
        StartCoroutine(LoadSceneAfterSE("Stage1"));
    }

    // コルーチンで再生終了を待つ
    private IEnumerator LoadSceneAfterSE(string sceneName)
    {
        // `playSE` が再生中である限り待機
        while (audioSource.isPlaying)
        {
            yield return null; // フレームごとに待機
        }

        // シーンをロード
        SceneManager.LoadScene(sceneName);
    }


    public void OnExitButtonPressed()
    {
        audioSource.PlayOneShot(SE);
        Application.Quit();
    }

    public void OnInstructionButtonPressed()
    {
        audioSource.PlayOneShot(SE);
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true);
        }
    }

    public void OnBackButtonPressed()
    {

        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false);
        }
    }

   


}
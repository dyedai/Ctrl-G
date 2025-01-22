using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//public class TitleScreenManager : MonoBehaviour
//{
//    // UI���܂�Canvas�S�̂ւ̎Q��
//    [SerializeField] private Canvas mainCanvas;
//    [SerializeField] private GameObject instructionPanel;
//    public static TitleScreenManager Instance { get; private set; }
//    public static float totalPlayTime = 0f;
//    private static bool isTimerRunning = false;  // static�ɕύX

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

//        // Canvas�S�̂�DontDestroyOnLoad�ɐݒ�
//        if (mainCanvas != null)
//        {
//            DontDestroyOnLoad(mainCanvas.gameObject);
//        }

//        // TitleScreenManager��DontDestroyOnLoad�ɐݒ�
//        DontDestroyOnLoad(gameObject);

//        // �V�[���؂�ւ����̃C�x���g���X�i�[��ǉ�
//        SceneManager.sceneLoaded += OnSceneLoaded;
//    }

//    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//    {
//        if (scene.name == "Title")
//        {
//            // �^�C�g���V�[���̏ꍇ��Canvas��\��
//            if (mainCanvas != null)
//            {
//                mainCanvas.gameObject.SetActive(true);
//            }
//        }
//        else
//        {
//            // �^�C�g���ȊO�̃V�[���ł�Canvas���\��
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
//        Debug.Log("�X�^�[�g");
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
    //    GameTimer.ResetTimer();//�^�C�}�[���Z�b�g
    //    GameTimer.StartTimer(); // �^�C�}�[���J�n
    //    Debug.Log("�X�^�[�g");
    //    Cursor.visible = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    //    SceneManager.LoadScene("Stage1");
    //}
    public void OnStartButtonPressed()
    {
        audioSource.PlayOneShot(playSE); // ���ʉ����Đ�
        GameTimer.ResetTimer();          // �^�C�}�[���Z�b�g
        GameTimer.StartTimer();          // �^�C�}�[���J�n
        Debug.Log("�X�^�[�g");
        Cursor.visible = false;          // �J�[�\�����\��
        Cursor.lockState = CursorLockMode.Locked; // �J�[�\�������b�N

        // �R���[�`�����J�n���ăV�[�����[�h��x��������
        StartCoroutine(LoadSceneAfterSE("Stage1"));
    }

    // �R���[�`���ōĐ��I����҂�
    private IEnumerator LoadSceneAfterSE(string sceneName)
    {
        // `playSE` ���Đ����ł������ҋ@
        while (audioSource.isPlaying)
        {
            yield return null; // �t���[�����Ƃɑҋ@
        }

        // �V�[�������[�h
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
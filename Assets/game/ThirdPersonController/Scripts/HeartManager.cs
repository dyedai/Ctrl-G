using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartManager : MonoBehaviour
{
    public static int heartCount; // ���݂̃n�[�g��
    public int defaultHeartCount = 3; // �f�t�H���g�̏����n�[�g��
    public int stage1HeartCount = 0; // Stage1 �̏����n�[�g��
    

    private static HeartManager instance;


    void InitializeHearts()
    {
        // ���݂̃V�[�������擾
        string currentScene = SceneManager.GetActiveScene().name;

        // �V�[������ "Stage1"or "Pre1" �̏ꍇ�͓��ʂȏ����l�ɐݒ�
        if (currentScene == "Stage1" || currentScene == "Pre1")
        {
            heartCount = stage1HeartCount;
        }
        else
        {
            heartCount = defaultHeartCount;
        }
    }

    // �V�[���J�ڎ��ɏ����n�[�g�����X�V����
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

using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PauseMenuManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSE;
    public AudioClip pauseSE;
    public GameObject pauseMenuUI;
    public GameObject controlsUI;
    public Text playTimeText;
    public GameObject playerArmature;
    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        controlsUI.SetActive(false);
    }

    void Update()
    {
        // Esc�L�[�̏���
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        // �^�C�}�[�̍X�V�𖈃t���[���s��
        GameTimer.UpdateTimer();

        // �^�C�}�[�\���̍X�V
        if (GameTimer.IsTimerRunning)
        {
            UpdatePlayTimeDisplay();
        }
    }

    private void UpdatePlayTimeDisplay()
    {
        playTimeText.text = "Play Time: " + GameTimer.GetFormattedTime();
        // �f�o�b�O�p
        //Debug.Log($"Displaying time: {GameTimer.GetFormattedTime()}");
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        audioSource.PlayOneShot(pauseSE);

        if (playerArmature != null)
        {
            var controller = playerArmature.GetComponent<ThirdPersonController>();
            if (controller != null) controller.enabled = false;
        }

        //playTimeText.text = $"Play Time: {GameTimer.GetFormattedTime()}";
        pauseMenuUI.SetActive(true);
    }

    //�Q�[�����ĊJ���ă��j���[�����
        public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // �Q�[�����ĊJ
        Cursor.lockState = CursorLockMode.Locked; // �}�E�X���\��
        Cursor.visible = false;

        // �v���C���[�̃R���g���[���[��L����
        if (playerArmature != null)
        {
            var controller = playerArmature.GetComponent<ThirdPersonController>();
            if (controller != null) controller.enabled = true;
        }

        pauseMenuUI.SetActive(false);
    }

    // ���݂̃V�[���������[�h
    public void RetryGame()
    {
        audioSource.PlayOneShot(clickSE);
        Time.timeScale = 1f; // �Q�[�����ĊJ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // �^�C�g���V�[���Ɉړ�
    public void GoToTitle()
    {
        audioSource.PlayOneShot(clickSE);
        Time.timeScale = 1f; // �Q�[�����ĊJ
        SceneManager.LoadScene("Title"); // �^�C�g���V�[���̖��O��ݒ�
    }

    // �������UI��\��
    public void ShowControls()
    {
        audioSource.PlayOneShot(clickSE);
        controlsUI.SetActive(true);
    }

    // �������UI���\��
    public void CloseControls()
    {
        controlsUI.SetActive(false);
    }
}

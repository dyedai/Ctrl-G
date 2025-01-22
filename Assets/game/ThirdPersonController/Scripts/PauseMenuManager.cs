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
        // Escキーの処理
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

        // タイマーの更新を毎フレーム行う
        GameTimer.UpdateTimer();

        // タイマー表示の更新
        if (GameTimer.IsTimerRunning)
        {
            UpdatePlayTimeDisplay();
        }
    }

    private void UpdatePlayTimeDisplay()
    {
        playTimeText.text = "Play Time: " + GameTimer.GetFormattedTime();
        // デバッグ用
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

    //ゲームを再開してメニューを閉じる
        public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // ゲームを再開
        Cursor.lockState = CursorLockMode.Locked; // マウスを非表示
        Cursor.visible = false;

        // プレイヤーのコントローラーを有効化
        if (playerArmature != null)
        {
            var controller = playerArmature.GetComponent<ThirdPersonController>();
            if (controller != null) controller.enabled = true;
        }

        pauseMenuUI.SetActive(false);
    }

    // 現在のシーンをリロード
    public void RetryGame()
    {
        audioSource.PlayOneShot(clickSE);
        Time.timeScale = 1f; // ゲームを再開
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // タイトルシーンに移動
    public void GoToTitle()
    {
        audioSource.PlayOneShot(clickSE);
        Time.timeScale = 1f; // ゲームを再開
        SceneManager.LoadScene("Title"); // タイトルシーンの名前を設定
    }

    // 操作説明UIを表示
    public void ShowControls()
    {
        audioSource.PlayOneShot(clickSE);
        controlsUI.SetActive(true);
    }

    // 操作説明UIを非表示
    public void CloseControls()
    {
        controlsUI.SetActive(false);
    }
}

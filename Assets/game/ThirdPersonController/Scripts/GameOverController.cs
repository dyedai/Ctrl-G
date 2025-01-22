using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // ゲームオーバー画面のパネル
    public GameObject RetryButton;
    public Transform startPosition; // シーンの初期位置
    public AudioSource audioSource;
    public AudioClip SE;
    public AudioClip FallSE;

    void Start()
    {
        CoinManager.CoinCount = 0;
        // ゲームオーバーパネルを非表示にする
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        if (RetryButton != null)
        {
            RetryButton.SetActive(false);
        }

        // カーソルの初期設定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // HeartManager.heartCount が 0 ならゲームオーバー画面を表示
        if (HeartManager.heartCount <= 0)
        {
            audioSource.PlayOneShot(SE);
            GameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Tag が "Hole" のコライダーに触れた場合
        if (other.gameObject.CompareTag("Hole"))
        {
            Debug.Log("落ちた - 現在の座標: " + transform.position);
            Debug.Log("開始位置: " + startPosition.position);

            HeartManager.heartCount--; // ハートを減らす

            if (HeartManager.heartCount > 0)
            {
                audioSource.PlayOneShot(FallSE);
                // 初期位置に戻る
                ResetToStartPosition();
                Debug.Log("リセット後の座標: " + transform.position);
            }
        }
    }

    void ResetToStartPosition()
    {
        // トランスフォームの位置を直接設定
        transform.position = startPosition.position;

        // キャラクターコントローラーを使用している場合
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
            transform.position = startPosition.position;
            controller.enabled = true;
        }

        
    }

    void GameOver()
    {
        // ゲームオーバーパネルを表示
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // リトライボタンを表示
        if (RetryButton != null)
        {
            RetryButton.SetActive(true);
        }

        // カーソルを表示
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // プレイヤーの移動を停止する処理（必要に応じて）
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
        }

        
    }

    // Retryボタン用の関数
    public void RetryGame()
    {
        // カーソルを元に戻す
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CoinManager.CoinCount = 0;

        // シーンをリロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
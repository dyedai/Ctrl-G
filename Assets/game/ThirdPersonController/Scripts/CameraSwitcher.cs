using StarterAssets;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [Tooltip("The camera to switch to when interacting with the object")]
    public Camera targetCamera; // 切り替える対象のカメラ
    public Camera mainCamera; // メインカメラ
    public GameObject playerArmature; // プレイヤーキャラクター (ThirdPersonControllerがアタッチされているオブジェクト)
    public GameObject UIText;

    private float distance; // 距離を測る変数
    private Vector3 direction; // カメラとオブジェクトの方向ベクトル
    private float angleView; // 視野角
    private bool isCameraSwitched = false; // カメラ切り替え状態を追跡するフラグ

    void Start()
    {
        // カメラの参照確認
        if (mainCamera == null)
            mainCamera = Camera.main; // メインカメラを自動取得
        if (targetCamera == null)
            Debug.LogError("ターゲットカメラが設定されていません");

        // 初期状態でメインカメラをアクティブにし、ターゲットカメラを非アクティブ化
        if (mainCamera != null) mainCamera.gameObject.SetActive(true);
        if (targetCamera != null) targetCamera.gameObject.SetActive(false);

        // メインカメラのtagをターゲットカメラにも付ける
        if (targetCamera != null)
            targetCamera.tag = "MainCamera"; // ターゲットカメラにもMainCameraタグを付ける
    }

    void Update()
    {
        // プレイヤーがオブジェクトに近づいてEキーを押した場合
        if (Input.GetKeyDown(KeyCode.E) && NearView())
        {
            SwitchToTargetCamera(); // ターゲットカメラに切り替える
            UIText.SetActive(false);
        }

        // 右クリックでメインカメラに戻る
        if (Input.GetMouseButtonDown(1) && isCameraSwitched)
        {
            SwitchToMainCamera(); // メインカメラに戻す
            UIText.SetActive(true);
        }
    }

    // プレイヤーが近くにいるか判定
    private bool NearView()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        return angleView < 45f && distance < 5f; // 条件を満たす場合にtrueを返す
    }

    // ターゲットカメラに切り替える
    private void SwitchToTargetCamera()
    {
        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(false);
            Debug.Log("メインカメラを非アクティブにしました");
        }
        if (targetCamera != null)
        {
            // ターゲットカメラがアクティブでない場合、アクティブ化する
            if (!targetCamera.gameObject.activeSelf)
            {
                targetCamera.gameObject.SetActive(true); // ターゲットカメラを有効化
                Debug.Log($"ターゲットカメラ {targetCamera.name} をアクティブにしました");
            }
        }

        // メインカメラのtagをターゲットカメラにも付ける
        if (targetCamera != null)
            targetCamera.tag = "MainCamera"; // ターゲットカメラにMainCameraタグを付ける

        // マウスカーソルを表示してロックを解除
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // プレイヤーのコントローラーを無効化
        if (playerArmature != null)
        {
            var controller = playerArmature.GetComponent<ThirdPersonController>();
            if (controller != null) controller.enabled = false;
        }

        // 物理時間を停止
        Time.timeScale = 0f;

        isCameraSwitched = true;
        Debug.Log("ターゲットカメラに切り替えました");
    }

    // メインカメラに戻す
    private void SwitchToMainCamera()
    {
        if (targetCamera != null) targetCamera.gameObject.SetActive(false);
        if (mainCamera != null) mainCamera.gameObject.SetActive(true);

        // メインカメラのtagをターゲットカメラに戻す
        if (mainCamera != null)
            mainCamera.tag = "MainCamera"; // メインカメラにMainCameraタグを付ける

        // マウスカーソルを非表示にしてロック
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // プレイヤーのコントローラーを有効化
        if (playerArmature != null)
        {
            var controller = playerArmature.GetComponent<ThirdPersonController>();
            if (controller != null) controller.enabled = true;
        }

        // 物理時間を再開
        Time.timeScale = 1f;

        isCameraSwitched = false;
        Debug.Log("メインカメラに戻しました");
    }
}

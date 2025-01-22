using UnityEngine;
using UnityEngine.UI; // UI用

public class PickUpObject : MonoBehaviour
{
    public Transform playerHand; // プレイヤーの手の位置
    public float objectScale = 0.5f; // 持ったときのサイズ
    private Vector3 originalPosition; // オブジェクトの元の位置
    private Vector3 originalScale; // オブジェクトの元のサイズ
    private bool isHeld = false; // オブジェクトを持っているかどうか
    private Rigidbody rb; // Rigidbody参照
    private bool isEnter; // 当たり判定の状態

    public GameObject pickupText; // Pickup 表示用の GameObject
    public GameObject putText;   // Put 表示用の GameObject

    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbodyがアタッチされていません: " + gameObject.name);
        }

        if (pickupText == null || putText == null)
        {
            Debug.LogError("pickupText または putText が設定されていません。インスペクターで設定してください: " + gameObject.name);
        }
        else
        {
            // 両方のテキストを非表示にしておく
            pickupText.SetActive(false);
            putText.SetActive(false);
        }
    }

    void Update()
    {
        if (isHeld)
        {
            // オブジェクトを持っている場合は Put のテキストを表示
            putText.SetActive(true);
            pickupText.SetActive(false);
        }
        else if (isEnter)
        {
            // プレイヤーが近くにいる場合は Pickup のテキストを表示
            
            pickupText.SetActive(true);
            putText.SetActive(false);

            // Eキーでオブジェクトを持つ
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Eキーが押され、オブジェクトを持ち上げます。");
                PickUp();
            }
        }
        else
        {
            //両方のテキストを非表示
            pickupText.SetActive(false);
            putText.SetActive(false);
        }

        // 持っている状態で左クリックでドロップ
        if (isHeld && Input.GetMouseButtonDown(0))
        {
            isEnter = false;
            Debug.Log("Left Clickが押され、オブジェクトをドロップします。");
            DropObject();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEnter = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEnter = false;
        }
    }

    void PickUp()
    {
        rb.isKinematic = true;
        transform.SetParent(playerHand);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = originalScale * objectScale;
        Debug.Log("オブジェクトを持ち上げました。");
        isHeld = true;
    }

    void DropObject()
    {
        isHeld = false;
        rb.isKinematic = false;
        transform.SetParent(null);
        transform.localScale = originalScale;

        // プレイヤーの少し前に配置
        float dropDistance = 1.0f;
        Vector3 dropPosition = playerHand.position + playerHand.forward * dropDistance;
        transform.position = dropPosition;

        transform.rotation = Quaternion.identity;
        Debug.Log("オブジェクトを少し前に置きました。");
    }
}

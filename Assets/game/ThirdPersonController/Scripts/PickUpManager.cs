using UnityEngine;
using UnityEngine.UI; // UI�p

public class PickUpObject : MonoBehaviour
{
    public Transform playerHand; // �v���C���[�̎�̈ʒu
    public float objectScale = 0.5f; // �������Ƃ��̃T�C�Y
    private Vector3 originalPosition; // �I�u�W�F�N�g�̌��̈ʒu
    private Vector3 originalScale; // �I�u�W�F�N�g�̌��̃T�C�Y
    private bool isHeld = false; // �I�u�W�F�N�g�������Ă��邩�ǂ���
    private Rigidbody rb; // Rigidbody�Q��
    private bool isEnter; // �����蔻��̏��

    public GameObject pickupText; // Pickup �\���p�� GameObject
    public GameObject putText;   // Put �\���p�� GameObject

    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody���A�^�b�`����Ă��܂���: " + gameObject.name);
        }

        if (pickupText == null || putText == null)
        {
            Debug.LogError("pickupText �܂��� putText ���ݒ肳��Ă��܂���B�C���X�y�N�^�[�Őݒ肵�Ă�������: " + gameObject.name);
        }
        else
        {
            // �����̃e�L�X�g���\���ɂ��Ă���
            pickupText.SetActive(false);
            putText.SetActive(false);
        }
    }

    void Update()
    {
        if (isHeld)
        {
            // �I�u�W�F�N�g�������Ă���ꍇ�� Put �̃e�L�X�g��\��
            putText.SetActive(true);
            pickupText.SetActive(false);
        }
        else if (isEnter)
        {
            // �v���C���[���߂��ɂ���ꍇ�� Pickup �̃e�L�X�g��\��
            
            pickupText.SetActive(true);
            putText.SetActive(false);

            // E�L�[�ŃI�u�W�F�N�g������
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E�L�[��������A�I�u�W�F�N�g�������グ�܂��B");
                PickUp();
            }
        }
        else
        {
            //�����̃e�L�X�g���\��
            pickupText.SetActive(false);
            putText.SetActive(false);
        }

        // �����Ă����Ԃō��N���b�N�Ńh���b�v
        if (isHeld && Input.GetMouseButtonDown(0))
        {
            isEnter = false;
            Debug.Log("Left Click��������A�I�u�W�F�N�g���h���b�v���܂��B");
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
        Debug.Log("�I�u�W�F�N�g�������グ�܂����B");
        isHeld = true;
    }

    void DropObject()
    {
        isHeld = false;
        rb.isKinematic = false;
        transform.SetParent(null);
        transform.localScale = originalScale;

        // �v���C���[�̏����O�ɔz�u
        float dropDistance = 1.0f;
        Vector3 dropPosition = playerHand.position + playerHand.forward * dropDistance;
        transform.position = dropPosition;

        transform.rotation = Quaternion.identity;
        Debug.Log("�I�u�W�F�N�g�������O�ɒu���܂����B");
    }
}

using StarterAssets;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [Tooltip("The camera to switch to when interacting with the object")]
    public Camera targetCamera; // �؂�ւ���Ώۂ̃J����
    public Camera mainCamera; // ���C���J����
    public GameObject playerArmature; // �v���C���[�L�����N�^�[ (ThirdPersonController���A�^�b�`����Ă���I�u�W�F�N�g)
    public GameObject UIText;

    private float distance; // �����𑪂�ϐ�
    private Vector3 direction; // �J�����ƃI�u�W�F�N�g�̕����x�N�g��
    private float angleView; // ����p
    private bool isCameraSwitched = false; // �J�����؂�ւ���Ԃ�ǐՂ���t���O

    void Start()
    {
        // �J�����̎Q�Ɗm�F
        if (mainCamera == null)
            mainCamera = Camera.main; // ���C���J�����������擾
        if (targetCamera == null)
            Debug.LogError("�^�[�Q�b�g�J�������ݒ肳��Ă��܂���");

        // ������ԂŃ��C���J�������A�N�e�B�u�ɂ��A�^�[�Q�b�g�J�������A�N�e�B�u��
        if (mainCamera != null) mainCamera.gameObject.SetActive(true);
        if (targetCamera != null) targetCamera.gameObject.SetActive(false);

        // ���C���J������tag���^�[�Q�b�g�J�����ɂ��t����
        if (targetCamera != null)
            targetCamera.tag = "MainCamera"; // �^�[�Q�b�g�J�����ɂ�MainCamera�^�O��t����
    }

    void Update()
    {
        // �v���C���[���I�u�W�F�N�g�ɋ߂Â���E�L�[���������ꍇ
        if (Input.GetKeyDown(KeyCode.E) && NearView())
        {
            SwitchToTargetCamera(); // �^�[�Q�b�g�J�����ɐ؂�ւ���
            UIText.SetActive(false);
        }

        // �E�N���b�N�Ń��C���J�����ɖ߂�
        if (Input.GetMouseButtonDown(1) && isCameraSwitched)
        {
            SwitchToMainCamera(); // ���C���J�����ɖ߂�
            UIText.SetActive(true);
        }
    }

    // �v���C���[���߂��ɂ��邩����
    private bool NearView()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        return angleView < 45f && distance < 5f; // �����𖞂����ꍇ��true��Ԃ�
    }

    // �^�[�Q�b�g�J�����ɐ؂�ւ���
    private void SwitchToTargetCamera()
    {
        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(false);
            Debug.Log("���C���J�������A�N�e�B�u�ɂ��܂���");
        }
        if (targetCamera != null)
        {
            // �^�[�Q�b�g�J�������A�N�e�B�u�łȂ��ꍇ�A�A�N�e�B�u������
            if (!targetCamera.gameObject.activeSelf)
            {
                targetCamera.gameObject.SetActive(true); // �^�[�Q�b�g�J������L����
                Debug.Log($"�^�[�Q�b�g�J���� {targetCamera.name} ���A�N�e�B�u�ɂ��܂���");
            }
        }

        // ���C���J������tag���^�[�Q�b�g�J�����ɂ��t����
        if (targetCamera != null)
            targetCamera.tag = "MainCamera"; // �^�[�Q�b�g�J������MainCamera�^�O��t����

        // �}�E�X�J�[�\����\�����ă��b�N������
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // �v���C���[�̃R���g���[���[�𖳌���
        if (playerArmature != null)
        {
            var controller = playerArmature.GetComponent<ThirdPersonController>();
            if (controller != null) controller.enabled = false;
        }

        // �������Ԃ��~
        Time.timeScale = 0f;

        isCameraSwitched = true;
        Debug.Log("�^�[�Q�b�g�J�����ɐ؂�ւ��܂���");
    }

    // ���C���J�����ɖ߂�
    private void SwitchToMainCamera()
    {
        if (targetCamera != null) targetCamera.gameObject.SetActive(false);
        if (mainCamera != null) mainCamera.gameObject.SetActive(true);

        // ���C���J������tag���^�[�Q�b�g�J�����ɖ߂�
        if (mainCamera != null)
            mainCamera.tag = "MainCamera"; // ���C���J������MainCamera�^�O��t����

        // �}�E�X�J�[�\�����\���ɂ��ă��b�N
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // �v���C���[�̃R���g���[���[��L����
        if (playerArmature != null)
        {
            var controller = playerArmature.GetComponent<ThirdPersonController>();
            if (controller != null) controller.enabled = true;
        }

        // �������Ԃ��ĊJ
        Time.timeScale = 1f;

        isCameraSwitched = false;
        Debug.Log("���C���J�����ɖ߂��܂���");
    }
}

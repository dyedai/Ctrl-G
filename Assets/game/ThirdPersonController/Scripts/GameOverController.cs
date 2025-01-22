using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // �Q�[���I�[�o�[��ʂ̃p�l��
    public GameObject RetryButton;
    public Transform startPosition; // �V�[���̏����ʒu
    public AudioSource audioSource;
    public AudioClip SE;
    public AudioClip FallSE;

    void Start()
    {
        CoinManager.CoinCount = 0;
        // �Q�[���I�[�o�[�p�l�����\���ɂ���
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        if (RetryButton != null)
        {
            RetryButton.SetActive(false);
        }

        // �J�[�\���̏����ݒ�
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // HeartManager.heartCount �� 0 �Ȃ�Q�[���I�[�o�[��ʂ�\��
        if (HeartManager.heartCount <= 0)
        {
            audioSource.PlayOneShot(SE);
            GameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Tag �� "Hole" �̃R���C�_�[�ɐG�ꂽ�ꍇ
        if (other.gameObject.CompareTag("Hole"))
        {
            Debug.Log("������ - ���݂̍��W: " + transform.position);
            Debug.Log("�J�n�ʒu: " + startPosition.position);

            HeartManager.heartCount--; // �n�[�g�����炷

            if (HeartManager.heartCount > 0)
            {
                audioSource.PlayOneShot(FallSE);
                // �����ʒu�ɖ߂�
                ResetToStartPosition();
                Debug.Log("���Z�b�g��̍��W: " + transform.position);
            }
        }
    }

    void ResetToStartPosition()
    {
        // �g�����X�t�H�[���̈ʒu�𒼐ڐݒ�
        transform.position = startPosition.position;

        // �L�����N�^�[�R���g���[���[���g�p���Ă���ꍇ
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
        // �Q�[���I�[�o�[�p�l����\��
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // ���g���C�{�^����\��
        if (RetryButton != null)
        {
            RetryButton.SetActive(true);
        }

        // �J�[�\����\��
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // �v���C���[�̈ړ����~���鏈���i�K�v�ɉ����āj
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
        }

        
    }

    // Retry�{�^���p�̊֐�
    public void RetryGame()
    {
        // �J�[�\�������ɖ߂�
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CoinManager.CoinCount = 0;

        // �V�[���������[�h
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
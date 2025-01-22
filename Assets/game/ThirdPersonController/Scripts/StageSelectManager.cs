using System.Collections;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip SE;
    private void Start()
    {
        // �J�[�\����\��
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // Esc�܂���Ctrl+G��Title�V�[���Ɉړ�
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.G)))
        {
            SceneManager.LoadScene("Title");
        }
    }

   

    // Stage1�{�^���������ꂽ���̏���
    public void LoadStage1()
    {
        audioSource.PlayOneShot(SE); // ���ʉ����Đ�
        Cursor.visible = false;          // �J�[�\�����\��
        Cursor.lockState = CursorLockMode.Locked; // �J�[�\�������b�N

       
        SceneManager.LoadScene("Pre1");
    }

   


    // Stage2�{�^���������ꂽ���̏���
    public void LoadStage2()
    {
        audioSource.PlayOneShot(SE); // ���ʉ����Đ�
        Cursor.visible = false;          // �J�[�\�����\��
        Cursor.lockState = CursorLockMode.Locked; // �J�[�\�������b�N

        SceneManager.LoadScene("Pre2");

    }

    // Stage3�{�^���������ꂽ���̏���
    public void LoadStage3()
    {
        audioSource.PlayOneShot(SE); // ���ʉ����Đ�
        Cursor.visible = false;          // �J�[�\�����\��
        Cursor.lockState = CursorLockMode.Locked; // �J�[�\�������b�N

        SceneManager.LoadScene("Pre3");
    }

    // Stage4�{�^���������ꂽ���̏���
    public void LoadStage4()
    {
        audioSource.PlayOneShot(SE); // ���ʉ����Đ�
        Cursor.visible = false;          // �J�[�\�����\��
        Cursor.lockState = CursorLockMode.Locked; // �J�[�\�������b�N

        SceneManager.LoadScene("Pre4");
    }

    // Title�V�[���Ɉړ����鏈��
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
}

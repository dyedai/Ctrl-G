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
        // カーソルを表示
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // EscまたはCtrl+GでTitleシーンに移動
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.G)))
        {
            SceneManager.LoadScene("Title");
        }
    }

   

    // Stage1ボタンが押された時の処理
    public void LoadStage1()
    {
        audioSource.PlayOneShot(SE); // 効果音を再生
        Cursor.visible = false;          // カーソルを非表示
        Cursor.lockState = CursorLockMode.Locked; // カーソルをロック

       
        SceneManager.LoadScene("Pre1");
    }

   


    // Stage2ボタンが押された時の処理
    public void LoadStage2()
    {
        audioSource.PlayOneShot(SE); // 効果音を再生
        Cursor.visible = false;          // カーソルを非表示
        Cursor.lockState = CursorLockMode.Locked; // カーソルをロック

        SceneManager.LoadScene("Pre2");

    }

    // Stage3ボタンが押された時の処理
    public void LoadStage3()
    {
        audioSource.PlayOneShot(SE); // 効果音を再生
        Cursor.visible = false;          // カーソルを非表示
        Cursor.lockState = CursorLockMode.Locked; // カーソルをロック

        SceneManager.LoadScene("Pre3");
    }

    // Stage4ボタンが押された時の処理
    public void LoadStage4()
    {
        audioSource.PlayOneShot(SE); // 効果音を再生
        Cursor.visible = false;          // カーソルを非表示
        Cursor.lockState = CursorLockMode.Locked; // カーソルをロック

        SceneManager.LoadScene("Pre4");
    }

    // Titleシーンに移動する処理
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
}

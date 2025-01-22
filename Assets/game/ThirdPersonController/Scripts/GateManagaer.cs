using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateManagaer : MonoBehaviour

{

    private void OnTriggerEnter(Collider other)
    {


        //ステージ2へ移動
        if (other.gameObject.CompareTag("GateCollider2"))
        {
            Debug.Log("Stage2へ移動するよ");
            
            SceneManager.LoadScene("Stage2");
            
        }

        //ステージ3へ移動
        if (other.gameObject.CompareTag("GateCollider3"))
        {
            Debug.Log("Stage3へ移動するよ");
            
            SceneManager.LoadScene("Stage3");

        }

        //ステージ4へ移動
        if (other.gameObject.CompareTag("GateCollider4"))
        {
            Debug.Log("Stage4へ移動するよ");
           
            SceneManager.LoadScene("Stage4");

        }

        //ステージfinalへ移動
        if (other.gameObject.CompareTag("GateColliderFinal"))
        {
            Debug.Log("StageFinalへ移動するよ");
            
            SceneManager.LoadScene("StageFinal");

        }

        //PreStage用
        if (other.gameObject.CompareTag("GateColliderPre"))
        {
            Debug.Log("ステージ選択に戻る");
          
            SceneManager.LoadScene("StageSelect");

        }

        //PreStage用
        if (other.gameObject.CompareTag("GateColliderTitle"))
        {
            Debug.Log("タイトルに戻る");
          
            SceneManager.LoadScene("Title");

        }
    }
}

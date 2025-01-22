using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateManagaer : MonoBehaviour

{

    private void OnTriggerEnter(Collider other)
    {


        //�X�e�[�W2�ֈړ�
        if (other.gameObject.CompareTag("GateCollider2"))
        {
            Debug.Log("Stage2�ֈړ������");
            
            SceneManager.LoadScene("Stage2");
            
        }

        //�X�e�[�W3�ֈړ�
        if (other.gameObject.CompareTag("GateCollider3"))
        {
            Debug.Log("Stage3�ֈړ������");
            
            SceneManager.LoadScene("Stage3");

        }

        //�X�e�[�W4�ֈړ�
        if (other.gameObject.CompareTag("GateCollider4"))
        {
            Debug.Log("Stage4�ֈړ������");
           
            SceneManager.LoadScene("Stage4");

        }

        //�X�e�[�Wfinal�ֈړ�
        if (other.gameObject.CompareTag("GateColliderFinal"))
        {
            Debug.Log("StageFinal�ֈړ������");
            
            SceneManager.LoadScene("StageFinal");

        }

        //PreStage�p
        if (other.gameObject.CompareTag("GateColliderPre"))
        {
            Debug.Log("�X�e�[�W�I���ɖ߂�");
          
            SceneManager.LoadScene("StageSelect");

        }

        //PreStage�p
        if (other.gameObject.CompareTag("GateColliderTitle"))
        {
            Debug.Log("�^�C�g���ɖ߂�");
          
            SceneManager.LoadScene("Title");

        }
    }
}

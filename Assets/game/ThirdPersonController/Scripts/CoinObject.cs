using UnityEngine;

public class CoinObject : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip SE;

    void Update()
    {
        // �R�C������]
        transform.Rotate(new Vector3(0, 0.5f, 0));
    }

    // �v���C���[�ƃn�[�g���G�ꂽ����s
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �v���C���[�Ɣ���
        {
            //�R�C��������
            audioSource.PlayOneShot(SE);
            Destroy(this.gameObject);
            


            CoinManager.CoinCount++;
            Debug.Log("Coin Count: " + HeartManager.heartCount);
        }
    }
}

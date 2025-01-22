using UnityEngine;

public class HeartObject : MonoBehaviour

{
    public AudioSource audioSource;
    public AudioClip SE;
    void Update()
    {
        // �n�[�g����]
        transform.Rotate(new Vector3(0, 0.5f, 0));
    }

    // �v���C���[�ƃn�[�g���G�ꂽ����s
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �v���C���[�Ɣ���
        {
            // �n�[�g������
            audioSource.PlayOneShot(SE);
            Destroy(this.gameObject);
            

            // HeartManager �̃n�[�g���𑝂₷
            HeartManager.heartCount++;
            Debug.Log("Heart Count: " + HeartManager.heartCount);
        }
    }
}

using UnityEngine;

public class HeartObject : MonoBehaviour

{
    public AudioSource audioSource;
    public AudioClip SE;
    void Update()
    {
        // ハートを回転
        transform.Rotate(new Vector3(0, 0.5f, 0));
    }

    // プレイヤーとハートが触れたら実行
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // プレイヤーと判定
        {
            // ハートを消滅
            audioSource.PlayOneShot(SE);
            Destroy(this.gameObject);
            

            // HeartManager のハート数を増やす
            HeartManager.heartCount++;
            Debug.Log("Heart Count: " + HeartManager.heartCount);
        }
    }
}

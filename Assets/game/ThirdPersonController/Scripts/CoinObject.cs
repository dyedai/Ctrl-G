using UnityEngine;

public class CoinObject : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip SE;

    void Update()
    {
        // コインを回転
        transform.Rotate(new Vector3(0, 0.5f, 0));
    }

    // プレイヤーとハートが触れたら実行
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // プレイヤーと判定
        {
            //コインを消滅
            audioSource.PlayOneShot(SE);
            Destroy(this.gameObject);
            


            CoinManager.CoinCount++;
            Debug.Log("Coin Count: " + HeartManager.heartCount);
        }
    }
}

using UnityEngine;
using UnityEngine.UI; // UI操作用の名前空間

public class HeartUI : MonoBehaviour
{
    public Image Health1;  // GameObjectからImageに変更
    public Image Health2;
    public Image Health3;
    public Sprite emptyHeartSprite; // 空のハート画像
    public Sprite fullHeartSprite;  // 満タンのハート画像

    void Update()
    {
        UpdateHeart(Health1, 1); // 1つ目のハートを更新
        UpdateHeart(Health2, 2); // 2つ目のハートを更新
        UpdateHeart(Health3, 3); // 3つ目のハートを更新
    }

    void UpdateHeart(Image health, int heartIndex)
    {
        // nullチェックを追加
        //if (health == null) return;

        if (HeartManager.heartCount >= heartIndex)
        {
            // heartCountが現在のheartIndex以上の場合、満タンハートを表示
            health.sprite = fullHeartSprite;
        }
        else
        {
            // heartCountが現在のheartIndex未満の場合、空のハートを表示
            health.sprite = emptyHeartSprite;
        }
    }
}
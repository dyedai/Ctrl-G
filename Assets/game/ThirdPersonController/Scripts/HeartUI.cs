using UnityEngine;
using UnityEngine.UI; // UI����p�̖��O���

public class HeartUI : MonoBehaviour
{
    public Image Health1;  // GameObject����Image�ɕύX
    public Image Health2;
    public Image Health3;
    public Sprite emptyHeartSprite; // ��̃n�[�g�摜
    public Sprite fullHeartSprite;  // ���^���̃n�[�g�摜

    void Update()
    {
        UpdateHeart(Health1, 1); // 1�ڂ̃n�[�g���X�V
        UpdateHeart(Health2, 2); // 2�ڂ̃n�[�g���X�V
        UpdateHeart(Health3, 3); // 3�ڂ̃n�[�g���X�V
    }

    void UpdateHeart(Image health, int heartIndex)
    {
        // null�`�F�b�N��ǉ�
        //if (health == null) return;

        if (HeartManager.heartCount >= heartIndex)
        {
            // heartCount�����݂�heartIndex�ȏ�̏ꍇ�A���^���n�[�g��\��
            health.sprite = fullHeartSprite;
        }
        else
        {
            // heartCount�����݂�heartIndex�����̏ꍇ�A��̃n�[�g��\��
            health.sprite = emptyHeartSprite;
        }
    }
}
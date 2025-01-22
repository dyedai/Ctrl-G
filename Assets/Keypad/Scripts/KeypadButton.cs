//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//namespace NavKeypad
//{
//    public class KeypadButton : MonoBehaviour
//    {
//        [Header("Value")]
//        [SerializeField] private string value;
//        [Header("Button Animation Settings")]
//        [SerializeField] private float bttnspeed = 0.1f;
//        [SerializeField] private float moveDist = 0.0025f;
//        [SerializeField] private float buttonPressedTime = 0.1f;
//        [Header("Component References")]
//        [SerializeField] private Keypad keypad;


//        public void PressButton()
//        {
//            if (!moving)
//            {
//                keypad.AddInput(value);
//                StartCoroutine(MoveSmooth());
//            }
//        }
//        private bool moving;

//        private IEnumerator MoveSmooth()
//        {

//            moving = true;
//            Vector3 startPos = transform.localPosition;
//            Vector3 endPos = transform.localPosition + new Vector3(0, 0, moveDist);

//            float elapsedTime = 0;
//            while (elapsedTime < bttnspeed)
//            {
//                elapsedTime += Time.deltaTime;
//                float t = Mathf.Clamp01(elapsedTime / bttnspeed);

//                transform.localPosition = Vector3.Lerp(startPos, endPos, t);

//                yield return null;
//            }
//            transform.localPosition = endPos;
//            yield return new WaitForSeconds(buttonPressedTime);
//            startPos = transform.localPosition;
//            endPos = transform.localPosition - new Vector3(0, 0, moveDist);

//            elapsedTime = 0;
//            while (elapsedTime < bttnspeed)
//            {
//                elapsedTime += Time.deltaTime;
//                float t = Mathf.Clamp01(elapsedTime / bttnspeed);

//                transform.localPosition = Vector3.Lerp(startPos, endPos, t);

//                yield return null;
//            }
//            transform.localPosition = endPos;

//            moving = false;
//        }
//    }
//}

using UnityEngine;
using System.Collections;

namespace NavKeypad
{
    public class KeypadButton : MonoBehaviour
    {
        [Header("Value")]
        [SerializeField] private string value;

        [Header("Button Animation Settings")]
        [SerializeField] private float bttnspeed = 0.1f;
        [SerializeField] private float moveDist = 0.0025f;
        [SerializeField] private float buttonPressedTime = 0.1f;

        [Header("Component References")]
        [SerializeField] private Keypad keypad;

        private Vector3 originalPosition;
        private bool isAnimating = false;
        private Coroutine currentAnimation = null;

        private void Start()
        {
            originalPosition = transform.localPosition;
        }

        public void PressButton()
        {
            if (!isAnimating && keypad != null)
            {
                keypad.AddInput(value);
                if (currentAnimation != null)
                {
                    StopCoroutine(currentAnimation);
                }
                currentAnimation = StartCoroutine(ButtonAnimation());
            }
        }

        private IEnumerator ButtonAnimation()
        {
            isAnimating = true;

            // 押し込みアニメーション
            Vector3 pressedPosition = originalPosition + Vector3.forward * moveDist;
            yield return StartCoroutine(MoveToPosition(pressedPosition, bttnspeed));

            // 押された状態を保持
            float timer = 0f;
            while (timer < buttonPressedTime)
            {
                timer += Time.unscaledDeltaTime;
                yield return null;
            }

            // 戻るアニメーション
            yield return StartCoroutine(MoveToPosition(originalPosition, bttnspeed));

            isAnimating = false;
            currentAnimation = null;
        }

        private IEnumerator MoveToPosition(Vector3 targetPosition, float duration)
        {
            Vector3 startPosition = transform.localPosition;
            float elapsedTime = 0;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(elapsedTime / duration);
                transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
                yield return null;
            }

            transform.localPosition = targetPosition;
        }

        private void OnDisable()
        {
            if (currentAnimation != null)
            {
                StopCoroutine(currentAnimation);
                currentAnimation = null;
            }
            transform.localPosition = originalPosition;
            isAnimating = false;
        }
    }
}
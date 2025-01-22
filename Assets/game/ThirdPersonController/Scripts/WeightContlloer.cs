using UnityEngine;
using UnityEngine.UI;

namespace StarterAssets
{
    public class WeightController : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip SE;
        public enum WeightState
        {
            Natural,
            Light,
            Heavy
        }

        [Header("Weight State Settings")]
        public WeightState CurrentWeightState = WeightState.Natural;

        [Header("Weight State Parameters")]
        [Tooltip("Multiplier for jump height in light state")]
        public float LightJumpMultiplier = 2f;
        [Tooltip("Multiplier for gravity in light state")]
        public float LightGravityMultiplier = 0.5f;

        [Tooltip("Multiplier for jump height in heavy state")]
        public float HeavyJumpMultiplier = 0.5f;
        [Tooltip("Multiplier for gravity in heavy state")]
        public float HeavyGravityMultiplier = 2f;

        [Header("UI References")]
        public Image NaturalButtonImage;
        public Image LightButtonImage;
        public Image HeavyButtonImage;

        private ThirdPersonController _thirdPersonController;
        private float _originalJumpHeight;
        private float _originalGravity;
        private StarterAssetsInputs _input;

        private void Start()
        {
            // Get references
            _thirdPersonController = GetComponent<ThirdPersonController>();
            _input = GetComponent<StarterAssetsInputs>();

            // Store original values
            _originalJumpHeight = _thirdPersonController.JumpHeight;
            _originalGravity = _thirdPersonController.Gravity;

            // Default to natural state
            SetNaturalState();
        }

        private void Update()
        {
            // Check for keyboard input to change weight state
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                audioSource.PlayOneShot(SE);
                SetHeavyState();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                audioSource.PlayOneShot(SE);
                SetNaturalState();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                audioSource.PlayOneShot(SE);
                SetLightState();
            }
        }

        public void SetNaturalState()
        {
            CurrentWeightState = WeightState.Natural;
            _thirdPersonController.JumpHeight = _originalJumpHeight;
            _thirdPersonController.Gravity = _originalGravity;
            _thirdPersonController.CanSprint = true;

            UpdateButtonColors();
        }

        public void SetLightState()
        {
            CurrentWeightState = WeightState.Light;
            _thirdPersonController.JumpHeight = _originalJumpHeight * LightJumpMultiplier;
            _thirdPersonController.Gravity = _originalGravity * LightGravityMultiplier;
            _thirdPersonController.CanSprint = false;

            UpdateButtonColors();
        }

        public void SetHeavyState()
        {
            CurrentWeightState = WeightState.Heavy;
            _thirdPersonController.JumpHeight = _originalJumpHeight * HeavyJumpMultiplier;
            _thirdPersonController.Gravity = _originalGravity * HeavyGravityMultiplier;
            _thirdPersonController.CanSprint = false;

            UpdateButtonColors();
        }

        private void UpdateButtonColors()
        {
            // Reset all button colors
            NaturalButtonImage.color = Color.white;
            LightButtonImage.color = Color.white;
            HeavyButtonImage.color = Color.white;

            // Highlight the current state button
            switch (CurrentWeightState)
            {
                case WeightState.Natural:
                    NaturalButtonImage.color = Color.green;
                    break;
                case WeightState.Light:
                    LightButtonImage.color = Color.green;
                    break;
                case WeightState.Heavy:
                    HeavyButtonImage.color = Color.green;
                    break;
            }
        }
    }
}
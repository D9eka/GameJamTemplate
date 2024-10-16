using System;
using UnityEngine;


namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private InputActions _inputActions;

        public Action PrimaryAttack;
        public Action AdditionalAttack;
        public Action Pause;

        public Action Interact;
        public Action Resume;

        public static InputManager Instance { get; private set; }

        public Vector2 GetMovementVectorNormalized()
        {
            return _inputActions.Player.Move.ReadValue<Vector2>().normalized;
        }

        public Vector2 GetRotationVectorNormalized()
        {
            return _inputActions.Player.RotateCamera.ReadValue<Vector2>().normalized;
        }

        private void Awake()
        {
            Instance = this;
            _inputActions = new InputActions();
        }

        private void Start()
        {
            _inputActions.UI.Enable();

            GameManager.Instance.StartGame += GameManager_StartGame;
            GameManager.Instance.EndGame += GameManager_EndGame;

            GameManager.Instance.PauseGame += GameManager_PauseGame;
            GameManager.Instance.ResumeGame += GameManager_ResumeGame;
        }

        private void GameManager_StartGame()
        {
            _inputActions.UI.Disable();
            _inputActions.Player.Enable();
        }

        private void GameManager_EndGame()
        {
            _inputActions.UI.Enable();
            _inputActions.Player.Disable();
        }

        private void GameManager_PauseGame()
        {
            _inputActions.UI.Enable();
            _inputActions.Player.Disable();
        }

        private void GameManager_ResumeGame()
        {
            _inputActions.UI.Disable();
            _inputActions.Player.Enable();
        }

        private void Update()
        {
            if (_inputActions.Player.enabled)
            {
                OnPause();
            }
            if (_inputActions.UI.enabled)
            {
                OnInteract();
                OnResume();
            }
        }

        private void OnPause()
        {
            if (_inputActions.Player.Pause.ReadValue<float>() > 0f)
            {
                Pause?.Invoke();
            }
        }

        private void OnInteract()
        {
            if (_inputActions.UI.Interact.ReadValue<float>() > 0f)
            {
                Interact?.Invoke();
            }
        }

        private void OnResume()
        {
            if (_inputActions.UI.Resume.ReadValue<float>() > 0f)
            {
                Resume?.Invoke();
            }
        }
    }
}

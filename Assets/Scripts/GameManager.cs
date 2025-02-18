using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool _started;
        private bool _paused;

        public Action StartGame;
        public Action EndGame;

        public Action PauseGame;
        public Action ResumeGame;

        public static GameManager Instance;

        public void OnStartGame()
        {
            EndGame?.Invoke();
            StartGame?.Invoke();
            _started = true;
        }

        public void OnResumeGame()
        {
            ResumeGame?.Invoke();
            _paused = false;
        }

        public void ReloadGame()
        {
            OnEndGame();
            _paused = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            InputManager.Instance.Interact += GameInput_Interact;
            InputManager.Instance.Pause += GameInput_Pause;
            InputManager.Instance.Resume += GameInput_Resume;
        }

        private void GameInput_Interact()
        {
            if (!_started)
            {
                OnStartGame();
            }
        }

        private void GameInput_Pause()
        {
            if (!_paused)
            {
                OnPauseGame();
            }
        }

        private void GameInput_Resume()
        {
            if (_started && _paused)
            {
                OnResumeGame();
            }
        }

        private void OnEndGame()
        {
            EndGame?.Invoke();
            _started = false;
        }

        private void OnPauseGame()
        {
            PauseGame?.Invoke();
            _paused = true;
        }
    }
}

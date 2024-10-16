using Screens;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            MainMenuScreen.Instance.Activate();

            GameManager.Instance.StartGame += GameManager_StartGame;
            GameManager.Instance.EndGame += GameManager_EndGame;

            GameManager.Instance.PauseGame += GameManager_PauseGame;
            GameManager.Instance.ResumeGame += GameManager_ResumeGame;
        }

        private void GameManager_StartGame()
        {
            Cursor.lockState = CursorLockMode.Locked;
            MainMenuScreen.Instance.Deactivate();

            HUDScreen.Instance.Activate();
        }

        private void GameManager_EndGame()
        {
            Cursor.lockState = CursorLockMode.None;
            HUDScreen.Instance.Deactivate();
            PauseScreen.Instance.Deactivate();

            MainMenuScreen.Instance.Activate();
        }

        private void GameManager_PauseGame()
        {
            Cursor.lockState = CursorLockMode.None;
            HUDScreen.Instance.Deactivate();

            PauseScreen.Instance.Activate();
        }

        private void GameManager_ResumeGame()
        {
            Cursor.lockState = CursorLockMode.Locked;
            PauseScreen.Instance.Deactivate();

            HUDScreen.Instance.Activate();
        }
    }
}

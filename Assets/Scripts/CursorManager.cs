using Managers;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EnableCursor();

        GameManager.Instance.StartGame += GameManager_StartGame;
        GameManager.Instance.EndGame += GameManager_EndGame;

        GameManager.Instance.PauseGame += GameManager_PauseGame;
        GameManager.Instance.ResumeGame += GameManager_ResumeGame;
    }

    private void GameManager_StartGame()
    {
        DisableCursor();
    }

    private void GameManager_EndGame()
    {
        EnableCursor();
    }

    private void GameManager_PauseGame()
    {
        EnableCursor();
    }

    private void GameManager_ResumeGame()
    {
        DisableCursor();
    }

    private void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void DisableCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
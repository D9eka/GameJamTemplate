using Creatures;
using Managers;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _UICamera;

    public static CameraManager Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EnableUICamera();

        GameManager.Instance.StartGame += GameManager_StartGame;
        GameManager.Instance.EndGame += GameManager_EndGame;

        GameManager.Instance.PauseGame += GameManager_PauseGame;
        GameManager.Instance.ResumeGame += GameManager_ResumeGame;
    }

    private void GameManager_StartGame()
    {
        EnablePlayerCamera();
    }

    private void GameManager_EndGame()
    {
        EnableUICamera();
    }

    private void GameManager_PauseGame()
    {
        EnableUICamera();
    }

    private void GameManager_ResumeGame()
    {
        EnablePlayerCamera();
    }



    private void EnablePlayerCamera()
    {
        PlayerCamera.Instance.enabled = true;
        _UICamera.enabled = false;
    }

    private void EnableUICamera()
    {
        _UICamera.enabled = true;
        PlayerCamera.Instance.enabled = false;
    }
}

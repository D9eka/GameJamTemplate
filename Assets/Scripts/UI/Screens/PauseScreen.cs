using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class PauseScreen : Screen
    {
        [Header("Buttons")]
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _exitButton;

        public static PauseScreen Instance;

        public override void Clear()
        {
        }

        private void Awake()
        {
            Instance = this;
        }

        protected override void Start()
        {
            base.Start();

            _resumeButton.onClick.RemoveAllListeners();
            _resumeButton.onClick.AddListener(() => GameManager.Instance.OnResumeGame());

            _exitButton.onClick.RemoveAllListeners();
            _exitButton.onClick.AddListener(() => GameManager.Instance.ReloadGame());
        }
    }
}
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class MainMenuScreen : Screen
    {
        [Header("Buttons")]
        [SerializeField] private Button _startButton;

        public static MainMenuScreen Instance;

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

            _startButton.onClick.RemoveAllListeners();
            _startButton.onClick.AddListener(() => GameManager.Instance.OnStartGame());
        }
    }
}
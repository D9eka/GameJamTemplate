using Managers;
using System.Collections;
using TMPro;
using UnityEngine;


namespace Screens
{
    public class HUDScreen : Screen
    {
        [Header("Text")]
        [SerializeField] private TextMeshProUGUI _elapsedTimeText;

        public static HUDScreen Instance;

        public override void Clear()
        {
            _elapsedTimeText.text = 0f.ToString();
        }

        private void Awake()
        {
            Instance = this;
        }

        protected override void Start()
        {
            base.Start();

            StartCoroutine(UpdateElapsedTime());
        }

        private IEnumerator UpdateElapsedTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                _elapsedTimeText.text = (float.Parse(_elapsedTimeText.text) + 1).ToString();
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}
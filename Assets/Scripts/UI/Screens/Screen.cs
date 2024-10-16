using Managers;
using UnityEngine;

namespace Screens
{
    public abstract class Screen : MonoBehaviour
    {
        [SerializeField] private GameObject _content;

        public abstract void Clear();

        public virtual void Activate()
        {
            _content.SetActive(true);
        }
        public virtual void Deactivate()
        {
            _content.SetActive(false);
        }

        protected virtual void Start()
        {
            Clear();

            GameManager.Instance.EndGame += GameManager_EndGame;
        }

        private void GameManager_EndGame()
        {
            Clear();
        }
    }
}
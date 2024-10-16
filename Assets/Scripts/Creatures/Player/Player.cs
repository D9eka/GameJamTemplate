using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Creatures
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform _orientation;
        [Header("Params")]
        [SerializeField] private Vector3 _initialPosition;
        [SerializeField] private float _movementSpeed = 50f;

        private Rigidbody _rigidbody;
        private BoxCollider _collider;

        public static Player Instance;

        private void Awake()
        {
            Instance = this;

            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.freezeRotation = true;

            _collider = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            GameManager.Instance.StartGame += GameManager_StartGame;
            GameManager.Instance.EndGame += GameManager_EndGame;

            gameObject.SetActive(false);
        }

        private void GameManager_StartGame()
        {
            gameObject.SetActive(true);
        }

        private void GameManager_EndGame()
        {
            transform.position = _initialPosition;
            gameObject.SetActive(false);
        }
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector2 movementVector = InputManager.Instance.GetMovementVectorNormalized(); 
            Vector3 moveDirection = _orientation.forward * movementVector.y + _orientation.right * movementVector.x;
            _rigidbody.AddForce(moveDirection.normalized * _movementSpeed, ForceMode.Force);
        }
    }
}

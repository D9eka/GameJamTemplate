using Managers;
using UnityEngine;

namespace Creatures
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private float _sensX = 400f;
        [SerializeField] private float _sensY = 400f;
        [SerializeField] private Transform _orientation;

        private float _xRotation;
        private float _yRotation;

        public static Camera Instance { get; private set; }

        private void Awake()
        {
            Instance = GetComponent<Camera>();
        }

        private void Update()
        {
            Vector2 mouseRotation = InputManager.Instance.GetRotationVectorNormalized();

            _xRotation -= mouseRotation.y * Time.deltaTime * _sensX;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            _yRotation += mouseRotation.x * Time.deltaTime * _sensY;

            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            _orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
        }
    }
}

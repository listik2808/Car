using CodeBase.CameraLogic;
using UnityEngine;
using UnityEngine.XR;

namespace Scripts
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _turningSpeed;
        [SerializeField] private Camera _camera;
        [SerializeField] private Car _car;

        private const float Epsilon = 0.01f;
        private IInputService _inputService;

        private void Start()
        {
            _inputService = new InputService();
            CameraFollow();
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Epsilon && _inputService.Axis.normalized.y > 0 || _inputService.Axis.normalized.x > 0)
            {
                _car.PlayWheelRotationForward();
                movementVector = SetDirection();
            }
            else if (_inputService.Axis.sqrMagnitude > Epsilon && _inputService.Axis.normalized.y < 0 || _inputService.Axis.normalized.x < 0)
            {
                _car.PlayWheelRotationBack();
                movementVector = SetDirection();
            }
            else
            {
                _car.DisableWheelRotationForward();
                _car.DisableWheelRotationBack();
            }

            transform.position += movementVector * _speed * Time.deltaTime;
        }

        private Vector3 SetDirection()
        {
            Vector3 movementVector = _camera.transform.TransformDirection(_inputService.Axis);
            movementVector.y = 0;
            movementVector.Normalize();
            transform.forward += movementVector * Time.deltaTime * _turningSpeed;
            return movementVector;
        }

        private void CameraFollow()
        {
            _camera.GetComponent<CameraFollow>().Follow(gameObject);
        }
    }
}
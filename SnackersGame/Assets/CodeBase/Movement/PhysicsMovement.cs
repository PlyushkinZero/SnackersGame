using System;
using UnityEngine;

namespace CodeBase.Components
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SurfaceSlider))]
    public class PhysicsMovement : MonoBehaviour
    {
        private const float ConstantMovementForward = 1f;
        private Rigidbody _rigidbody;
        private SurfaceSlider _surfaceSlider;
        [SerializeField] private float _speed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _surfaceSlider = GetComponent<SurfaceSlider>();
        }

        public void Move(Vector3 direction)
        {
            direction.z = ConstantMovementForward;

            Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            Vector3 offset = directionAlongSurface * (_speed * Time.fixedDeltaTime);

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}
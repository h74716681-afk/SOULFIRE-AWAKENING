using UnityEngine;
using Soulfire.Input;

namespace Soulfire.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class ThirdPersonMotor : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float moveSpeed = 5.5f;
        [SerializeField] private float rotationSpeed = 14f;
        [SerializeField] private float gravity = -22f;
        [SerializeField] private float dodgeSpeed = 10f;
        [SerializeField] private float dodgeDuration = 0.22f;
        private CharacterController controller;
        private Vector3 verticalVelocity;
        private float dodgeTimer;
        private Vector3 dodgeDirection;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            if (cameraTransform == null && Camera.main != null) cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            Vector2 input = RuntimeInputBridge.Move;
            Vector3 forward = cameraTransform ? Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized : Vector3.forward;
            Vector3 right = cameraTransform ? Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized : Vector3.right;
            Vector3 direction = Vector3.ClampMagnitude(forward * input.y + right * input.x, 1f);

            if (RuntimeInputBridge.ConsumeDodge() && direction.sqrMagnitude > 0.01f)
            {
                dodgeDirection = direction;
                dodgeTimer = dodgeDuration;
            }

            if (dodgeTimer > 0f)
            {
                dodgeTimer -= Time.deltaTime;
                direction = dodgeDirection;
                controller.Move(direction * dodgeSpeed * Time.deltaTime);
            }
            else
            {
                controller.Move(direction * moveSpeed * Time.deltaTime);
            }

            if (direction.sqrMagnitude > 0.01f)
            {
                Quaternion target = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);
            }

            if (controller.isGrounded && verticalVelocity.y < 0f) verticalVelocity.y = -2f;
            verticalVelocity.y += gravity * Time.deltaTime;
            controller.Move(verticalVelocity * Time.deltaTime);
        }
    }
}

using UnityEngine;

namespace Soulfire.CameraSystem
{
    public class ThirdPersonCameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new Vector3(0f, 3.2f, -5.5f);
        [SerializeField] private float followSmoothness = 12f;
        [SerializeField] private float lookHeight = 1.4f;

        private void LateUpdate()
        {
            if (target == null) return;
            Vector3 desiredPosition = target.position + target.rotation * offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, 1f - Mathf.Exp(-followSmoothness * Time.deltaTime));
            Vector3 lookPoint = target.position + Vector3.up * lookHeight;
            transform.rotation = Quaternion.LookRotation(lookPoint - transform.position, Vector3.up);
        }

        public void SetTarget(Transform newTarget) => target = newTarget;
    }
}

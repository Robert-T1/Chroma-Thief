using UnityEngine;

namespace TestCode
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float smoothSpeed = 0.125f;
        public Vector3 locationOffset;

        void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + target.rotation * locationOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float smoothing;


        private void FixedUpdate()
        {
            SmoothFollow();
        }

        private void SmoothFollow()
        {
            var nextPosition = Vector3.Lerp(transform.position, targetTransform.position + offset,
                Time.fixedDeltaTime * smoothing);
            transform.position = nextPosition;
        }
    }
}
using System;
using UnityEngine;
namespace Assets
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private float smoothing;

        public void SmoothFollow(GameObject target)
        {
            var nextPosition = Vector3.Lerp(transform.position, target.transform.position + offset,
                Time.fixedDeltaTime * smoothing);
            transform.position = nextPosition;
        }
    }
}
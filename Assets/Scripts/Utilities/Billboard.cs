using UnityEngine;

namespace PhotonTutorial.Utilities
{
    public class Billboard : MonoBehaviour
    {
        private Transform mainCameraTransform;

        private void Start()
        {
            mainCameraTransform = Camera.main.transform;
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward,
                mainCameraTransform.rotation * Vector3.up);
        }
    }
}

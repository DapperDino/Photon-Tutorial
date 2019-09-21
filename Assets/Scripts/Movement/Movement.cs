using Photon.Pun;
using UnityEngine;

namespace PhotonTutorial.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviourPun
    {
        [SerializeField] private float movementSpeed = 0f;

        private CharacterController controller = null;
        private Transform mainCameraTransform = null;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
            mainCameraTransform = Camera.main.transform;
        }

        void Update()
        {
            if (photonView.IsMine)
            {
                TakeInput();
            }
        }

        private void TakeInput()
        {
            var movement = new Vector3
            {
                x = Input.GetAxisRaw("Horizontal"),
                y = 0f,
                z = Input.GetAxisRaw("Vertical"),
            }.normalized;

            Vector3 forward = mainCameraTransform.forward;
            Vector3 right = mainCameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            Vector3 calculatedMovement = (forward * movement.z + right * movement.x).normalized;

            if (calculatedMovement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(calculatedMovement);
            }

            controller.SimpleMove(calculatedMovement * movementSpeed);
        }
    }
}

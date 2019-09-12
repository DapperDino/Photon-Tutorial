using Photon.Pun;
using UnityEngine;

namespace PhotonTutorial.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviourPun
    {
        [SerializeField] private float movementSpeed = 0f;

        private CharacterController controller = null;

        private void Start() => controller = GetComponent<CharacterController>();

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

            controller.SimpleMove(movement * movementSpeed);
        }
    }
}

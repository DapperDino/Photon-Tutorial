using System;
using Photon.Pun;
using UnityEngine;

namespace PhotonTutorial.Weapons
{
    public class Weapon : MonoBehaviourPun
    {
        [SerializeField] private float projectileSpeed = 5f;
        [SerializeField] private GameObject projectile = null;
        [SerializeField] private Transform spawnPoint = null;

        private void Update()
        {
            if (photonView.IsMine)
            {
                TakeInput();
            }
        }

        private void TakeInput()
        {
            if (!Input.GetMouseButtonDown(0)) { return; }

            photonView.RPC("FireProjectile", RpcTarget.All);
        }

        [PunRPC]
        private void FireProjectile()
        {
            var projectileInstance = Instantiate(
                projectile,
                spawnPoint.position,
                spawnPoint.rotation
            );

            projectileInstance.GetComponent<Rigidbody>().velocity = projectileInstance.transform.forward * projectileSpeed;
        }
    }
}

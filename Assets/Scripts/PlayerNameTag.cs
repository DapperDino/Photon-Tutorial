using Photon.Pun;
using TMPro;
using UnityEngine;

namespace PhotonTutorial
{
    public class PlayerNameTag : MonoBehaviourPun
    {
        [SerializeField] private TextMeshProUGUI nameText;

        private void Start()
        {
            if (photonView.IsMine) { return; }

            SetName();
        }

        private void SetName() => nameText.text = photonView.Owner.NickName;
    }
}

using Interactable;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput), typeof(PlayerMovement))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("LayerMask to identify interactables in the game environment.")]
        private LayerMask interactables;
        
        PlayerInput m_PlayerInput;
        PlayerMovement m_PlayerMovement;
        PlayerFX m_PlayerFX;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            m_PlayerInput = GetComponent<PlayerInput>();
            m_PlayerMovement = GetComponent<PlayerMovement>();
            m_PlayerFX = GetComponent<PlayerFX>();
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (interactables.ContainsLayer(hit.gameObject))
            {
                if (m_PlayerFX != null)
                    m_PlayerFX.PlayEffect();
                var collectible = hit.transform.parent.GetComponent<CollectibleObject>();
                collectible.Interact();
            }
        }

        private void LateUpdate()
        {
            Vector3 inputVector = m_PlayerInput.InputVector;
            m_PlayerMovement.Move(inputVector);
        }
    }
}

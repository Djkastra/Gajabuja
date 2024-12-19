using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [Header("Controls")]
        [Tooltip("Use WASD keys to move")]
        [SerializeField] private KeyCode m_ForwardKey = KeyCode.W;
        [SerializeField] private KeyCode m_BackwardKey = KeyCode.S;
        [SerializeField] private KeyCode m_LeftKey = KeyCode.A;
        [SerializeField] private KeyCode m_RightKey = KeyCode.D;

        private Vector3 m_InputVector;
        private float m_XInput;
        private float m_ZInput;
        private float m_YInput;

        public Vector3 InputVector => m_InputVector;

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            m_XInput = 0;
            m_ZInput = 0;

            if (Input.GetKey(m_ForwardKey))
            {
                m_ZInput++;
            }

            if (Input.GetKey(m_BackwardKey))
            {
                m_ZInput--;
            }

            if (Input.GetKey(m_LeftKey))
            {
                m_XInput--;
            }

            if (Input.GetKey(m_RightKey))
            {
                m_XInput++;
            }

            m_InputVector = new Vector3(m_XInput, m_YInput, m_ZInput);
        }
    }
}

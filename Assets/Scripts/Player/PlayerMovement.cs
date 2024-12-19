using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")] 
        [Tooltip("Horizontal speed")] [SerializeField]
        private float m_MoveSpeed = 5f;

        [Tooltip("Rate of change for move speed")] [SerializeField]
        private float m_Acceleration = 10f;

        [Tooltip("Deceleration rate when no input is provided")] [SerializeField]
        private float m_Deceleration = 5f;

        private float m_CurrentSpeed = 0f;
        private CharacterController m_CharController;
        private float m_InitialYPosition;
        private float m_SpeedMultiplier = 1f;

        private void Awake()
        {
            m_CharController = GetComponent<CharacterController>();
        }

        void Start()
        {
            m_InitialYPosition = transform.position.y;
        }

        public void Move(Vector3 inputVector)
        {
            if (inputVector == Vector3.zero)
            {
                if (m_CurrentSpeed > 0)
                {
                    m_CurrentSpeed -= m_Deceleration * Time.deltaTime;
                    m_CurrentSpeed = Mathf.Max(m_CurrentSpeed, 0);
                }
            }
            else
            {
                m_CurrentSpeed = Mathf.Lerp(m_CurrentSpeed, m_MoveSpeed, Time.deltaTime * m_Acceleration);
            }
            Vector3 movement = m_CurrentSpeed * m_SpeedMultiplier * Time.deltaTime * inputVector.normalized;
            m_CharController.Move(movement);
            transform.position = new Vector3(transform.position.x, m_InitialYPosition, transform.position.z);
        }
        
    }
}
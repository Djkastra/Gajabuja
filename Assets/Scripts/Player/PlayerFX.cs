using UnityEngine;

namespace Player
{
    public class PlayerFX : MonoBehaviour
    {
        [SerializeField]
        ParticleSystem m_ParticleSystem;

        const float k_Cooldown = 1f;

        float m_TimeToNextPlay = -1f;

        public void PlayEffect()
        {
            if (Time.time < m_TimeToNextPlay)
                return;

            if (m_ParticleSystem != null)
            {
                m_ParticleSystem.Stop();
                m_ParticleSystem.Play();

                m_TimeToNextPlay = Time.time + k_Cooldown;
            }
        }

    }
}

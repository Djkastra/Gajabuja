using System.Collections;
using UnityEngine;
namespace Interactable
{
    public abstract class CollectibleObject : MonoBehaviour
    {
        [Header("Feedback")] public ParticleSystem interactionParticles;
        public AudioSource interactionSound;

        [Header("Animation")] public Animator animator;

        private InteractionManager manager;

        private void Start()
        {
            manager = FindObjectOfType<InteractionManager>();
        }

        public virtual void Interact()
        {
            if (manager != null)
            {
                manager.RegisterInteraction();
            }

            PlayAnimation();
            PlayFeedback();
            StartCoroutine(HideObjectPostAnimation());
        }

        private void PlayAnimation()
        {
            if (animator)
            {
                animator.enabled = true;
            }
        }

        private IEnumerator HideObjectPostAnimation()
        {
            yield return new WaitForSeconds(1.5f);
            gameObject.SetActive(false);
        }

        private void PlayFeedback()
        {
            if (interactionParticles)
                interactionParticles.Play();

            // check if sound is active from playerprefs if yes play or ignore
            // better to create AudioManager and play all sound from there instead of here
            if (interactionSound)
            {
                interactionSound.Play();
            }
        }
    }
}
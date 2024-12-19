using UnityEngine;

namespace Interactable
{
    public class InteractionManager : MonoBehaviour
    {
        [Header("Final Animation Settings")] public Animator finalAnimator;
        public string finalAnimationTrigger = "PlayFinalAnimation";
        private int interactionsCount = 0;
        private int totalInteractables = 3;

        public void RegisterInteraction()
        {
            interactionsCount++;
            if (interactionsCount >= totalInteractables)
            {
                TriggerFinalAnimation();
            }
        }

        private void TriggerFinalAnimation()
        {
            if (finalAnimator != null)
            {
                finalAnimator.SetTrigger(finalAnimationTrigger);
            }
            Debug.Log("Final Animation Triggered!");
        }
    }
}
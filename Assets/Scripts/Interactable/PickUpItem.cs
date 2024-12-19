namespace Interactable
{
    public class PickUpItem : CollectibleObject
    {
        private bool isOpen = false;

        public override void Interact()
        {
            if (isOpen) return;

            base.Interact();
            isOpen = true;
        }
    }
}
namespace Interactable
{
    public class Door : CollectibleObject
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
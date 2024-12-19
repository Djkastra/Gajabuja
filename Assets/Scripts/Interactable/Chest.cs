namespace Interactable
{
    public class Chest : CollectibleObject
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
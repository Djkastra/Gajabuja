using UnityEngine;
using UnityEngine.UI;

namespace PopUp
{
    public class SettingPopup : PopupBase
    {
        [SerializeField] private Toggle soundToggle;

        private void Start()
        {
            soundToggle.onValueChanged.AddListener(OnSoundSettingChanged);
            OnSoundSettingChanged(soundToggle.isOn);
        }

        private void OnSoundSettingChanged(bool status)
        {
            if (status)
            {
                // mute audio or enable
                // Store in playerprefs or 
            }
        }

        public override void Show(float delay = 0)
        {
            base.Show(delay);
            gameObject.SetActive(true);
        }
    }
}

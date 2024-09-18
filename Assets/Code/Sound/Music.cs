using UnityEngine;
using UnityEngine.UI;

namespace Code.Sound
{
    public class Music : MonoBehaviour
    {
        [Header("UI Components")]
        public Button musicButton;

        public Image musicImage;

        [Header("Assets")]
        public Sprite musicOnSprite;

        public Sprite musicOffSprite;

        [Header("Audio")]
        public AudioSource audioSource;

        private bool _isMusicOn;

        private const string MusicStateKey = "MusicState";

        private void Start()
        {
            LoadMusicState();
            UpdateUI();
            musicButton.onClick.AddListener(ToggleMusic);
        }

        private void ToggleMusic()
        {
            _isMusicOn = !_isMusicOn;
            UpdateMusicState();
        }

        private void UpdateMusicState()
        {
            audioSource.mute = !_isMusicOn;
            UpdateUI();
            SaveMusicState();
        }

        private void UpdateUI()
        {
            musicImage.sprite = _isMusicOn ? musicOnSprite : musicOffSprite;
        }

        private void LoadMusicState()
        {
            _isMusicOn = PlayerPrefs.GetInt(MusicStateKey, 1) == 1;
        }

        private void SaveMusicState()
        {
            PlayerPrefs.SetInt(MusicStateKey, _isMusicOn ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}

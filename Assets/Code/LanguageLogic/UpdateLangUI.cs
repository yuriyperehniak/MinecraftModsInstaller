using UnityEngine;
using UnityEngine.UI;

namespace Code.LanguageLogic
{
    public class UpdateLangUI : MonoBehaviour
    {
        public static UpdateLangUI Instance;

        public Image parentWrapper;
        public Sprite singleWrapper;
        public Sprite multiWrapper;

        public float singleWrapperWidth = 63f;
        public float multiWrapperWidth = 165f;

        private RectTransform _parentWrapperRectTransform;
        private bool _isMenuOpen;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _parentWrapperRectTransform = parentWrapper.GetComponent<RectTransform>();
            _isMenuOpen = false;
            UpdateLanguageUI(LangChecker.Instance.GetCurrentLanguage());
        }

        public void ToggleLanguageMenu(string language)
        {
            if (!_isMenuOpen)
            {
                _isMenuOpen = true;
                UpdateLanguageUI(language);
            }
            else
            {
                LangChecker.Instance.SetLanguage(language);
                _isMenuOpen = false;
                UpdateLanguageUI(language);
            }
        }

        public void UpdateLanguageUI(string currentLanguage)
        {
            if (LangChecker.Instance != null)
            {
                if (LangChecker.Instance.GetCurrentLanguage() == currentLanguage && _isMenuOpen)
                {
                    foreach (var pair in LangChecker.Instance.languageButtons)
                    {
                        pair.button.gameObject.SetActive(true);
                    }
                    parentWrapper.sprite = multiWrapper;
                    UpdateWrapperWidth(multiWrapperWidth);
                }
                else
                {
                    foreach (var pair in LangChecker.Instance.languageButtons)
                    {
                        pair.button.gameObject.SetActive(pair.language == currentLanguage);
                    }
                    parentWrapper.sprite = singleWrapper;
                    UpdateWrapperWidth(singleWrapperWidth);
                }
            }
        }

        private void UpdateWrapperWidth(float newWidth)
        {
            if (_parentWrapperRectTransform != null)
            {
                _parentWrapperRectTransform.sizeDelta = new Vector2(newWidth, _parentWrapperRectTransform.sizeDelta.y);
            }
        }
    }
}

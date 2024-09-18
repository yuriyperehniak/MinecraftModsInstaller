using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.LanguageLogic
{
    public class LangChecker : MonoBehaviour
    {
        public static LangChecker Instance;

        public List<LangButtonPair> languageButtons = new List<LangButtonPair>();
        private string _currentLanguage;
        private Dictionary<Button, string> _languageDictionary = new Dictionary<Button, string>();

        private const string LanguagePrefKey = "SelectedLanguage";

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
            LoadLanguageState();
            InitializeLanguageButtons();
        }

        private void InitializeLanguageButtons()
        {
            foreach (var pair in languageButtons)
            {
                if (!_languageDictionary.ContainsKey(pair.button))
                {
                    _languageDictionary.Add(pair.button, pair.language);
                }

                pair.button.onClick.AddListener(() => OnLanguageButtonClick(pair.button));
            }

            UpdateLanguageUI();
        }

        private void OnLanguageButtonClick(Button clickedButton)
        {
            if (_languageDictionary.TryGetValue(clickedButton, out string selectedLanguage))
            {
                UpdateLangUI.Instance.ToggleLanguageMenu(selectedLanguage);
            }
        }

        public string GetCurrentLanguage()
        {
            return _currentLanguage;
        }

        public void SetLanguage(string newLanguage)
        {
            if (_currentLanguage != newLanguage)
            {
                _currentLanguage = newLanguage;
                SaveLanguageState();
            }
        }

        private void SaveLanguageState()
        {
            PlayerPrefs.SetString(LanguagePrefKey, _currentLanguage);
            PlayerPrefs.Save();
        }

        private void LoadLanguageState()
        {
            _currentLanguage = PlayerPrefs.GetString(LanguagePrefKey, "ru");
        }

        private void UpdateLanguageUI()
        {
            if (UpdateLangUI.Instance != null)
            {
                UpdateLangUI.Instance.UpdateLanguageUI(_currentLanguage);
            }
        }
    }
}

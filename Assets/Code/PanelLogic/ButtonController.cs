using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Code.PanelLogic
{
    public class ButtonController : MonoBehaviour
    {
        [FormerlySerializedAs("panelManager")] public PanelController panelController; // Посилання на PanelManager

        [System.Serializable]
        public struct ButtonPair
        {
            public Button button; // Кнопка
            public string key;    // Ключ панелі, яку показує ця кнопка
        }

        public List<ButtonPair> buttons = new List<ButtonPair>(); // Список кнопок і їх ключів

        private void Start()
        {
            // Ініціалізуємо кнопки і прив'язуємо до них ключі
            foreach (var pair in buttons)
            {
                if (pair.button != null && !string.IsNullOrEmpty(pair.key))
                {
                    pair.button.onClick.AddListener(() => OnButtonClick(pair.key)); // Додаємо обробник події
                }
            }
        }

        private void OnButtonClick(string key)
        {
            // Показуємо панель відповідно до ключа кнопки
            if (panelController != null)
            {
                panelController.ActivatePanel(key);
            }
            else
            {
                Debug.LogError("PanelManager is not assigned.");
            }
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Code.PanelLogic
{
    public class PanelController : MonoBehaviour
    {
        public static PanelController Instance;

        // Словник для панелей: ключ - ідентифікатор, значення - сама панель
        public List<PanelKeyPair> panels = new List<PanelKeyPair>();
        private Dictionary<string, GameObject> _panelDictionary = new Dictionary<string, GameObject>();

        private void Awake()
        {
            // Перевірка чи є вже екземпляр PanelManager
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
            InitializePanels();
        }

        // Ініціалізуємо всі панелі та зберігаємо їх у словнику
        private void InitializePanels()
        {
            foreach (var pair in panels)
            {
                if (!_panelDictionary.ContainsKey(pair.key))
                {
                    _panelDictionary.Add(pair.key, pair.panel);
                }
            }
        }

        // Вмикаємо певну панель і вимикаємо всі інші
        public void ActivatePanel(string key)
        {
            foreach (var panelPair in _panelDictionary)
            {
                panelPair.Value.SetActive(panelPair.Key == key);
            }
        }
    }

    [System.Serializable]
    public class PanelKeyPair
    {
        public string key; // Ідентифікатор панелі
        public GameObject panel; // Сама панель
    }
}
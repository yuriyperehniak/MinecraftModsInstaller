using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class ModInstallationUI : MonoBehaviour
    {
        public GameObject progressPanel;  // Панель, яка містить слайдер і текст
        public Slider progressBar;        // Slider для прогресу
        public TextMeshProUGUI progressText; // TextMeshProUGUI для відображення відсотків
        public Button startButton;        // Кнопка для початку
        public Button resetButton;        // Кнопка для перезапуску

        private void Start()
        {
            // Ініціалізація значень
            progressPanel.SetActive(false);   // Робимо панель неактивною на старті
            progressBar.value = 0;            // Початкове значення прогрес-бару
            progressText.text = "0%";         // Початковий текст
            resetButton.interactable = false; // Вимикаємо кнопку ресету
            startButton.onClick.AddListener(StartInstallation); // Прив'язуємо старт до кнопки
            resetButton.onClick.AddListener(ResetInstallation); // Прив'язуємо ресет до кнопки
        }

        // Метод для запуску установки
        public void StartInstallation()
        {
            progressPanel.SetActive(true);     // Активуємо панель зі слайдером
            startButton.interactable = false;  // Вимикаємо кнопку старту під час установки
            StartCoroutine(InstallationRoutine()); // Запускаємо корутину
        }

        // Корутіна для симуляції установки з затримкою
        private IEnumerator InstallationRoutine()
        {
            // Затримка перед початком установки
            yield return new WaitForSeconds(1f);

            StartCoroutine(SimulateInstallation()); // Запускаємо симуляцію установки
        }

        // Симуляція установки
        private IEnumerator SimulateInstallation()
        {
            float duration = 5f; // 5 секунд
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float progress = Mathf.Clamp01(elapsedTime / duration) * 100f;
                progressBar.value = progress; // Оновлюємо прогрес
                progressText.text = $"{progress:F0}%"; // Оновлюємо текст відсотками

                yield return null; // Чекаємо наступного кадру
            }

            progressBar.value = 100f;   // Установлюємо 100%
            progressText.text = "100%"; // Відображаємо 100%
            resetButton.interactable = true; // Дозволяємо ресет
        }

        // Метод для скидання установки
        public void ResetInstallation()
        {
            progressBar.value = 0;        // Скидаємо прогрес
            progressText.text = "0%";     // Скидаємо текст
            resetButton.interactable = false;  // Вимикаємо кнопку ресету
            startButton.interactable = true;   // Вмикаємо кнопку старту знову
            progressPanel.SetActive(false);    // Деактивуємо панель після скидання
        }
    }
}

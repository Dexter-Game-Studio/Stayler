using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    private void Start()
    {
        ResumeGame();
    }


    void Update()
    {
        // Проверка нажатия кнопки ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // Поставить игру на паузу
        Time.timeScale = 0f;
        isPaused = true;

        // Отобразить диалоговое окно
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        // Возобновить игру
        Time.timeScale = 1f;
        isPaused = false;

        // Скрыть диалоговое окно
        pauseMenu.SetActive(false);
    }

    // Дополнительные методы для обработки кнопок меню
    public void RestartGame()
    {
        SceneManager.LoadScene(1);

        ResumeGame(); // После перезапуска, продолжить игру
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenSettings()
    {
        
    }
}

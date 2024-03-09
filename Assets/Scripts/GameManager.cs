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
        // �������� ������� ������ ESC
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
        // ��������� ���� �� �����
        Time.timeScale = 0f;
        isPaused = true;

        // ���������� ���������� ����
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        // ����������� ����
        Time.timeScale = 1f;
        isPaused = false;

        // ������ ���������� ����
        pauseMenu.SetActive(false);
    }

    // �������������� ������ ��� ��������� ������ ����
    public void RestartGame()
    {
        SceneManager.LoadScene(1);

        ResumeGame(); // ����� �����������, ���������� ����
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenSettings()
    {
        
    }
}

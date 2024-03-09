using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Вызывается при нажатии на кнопку или другое событие
    public void Exit()
    {
        // Проверка, работает ли приложение в редакторе Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Если приложение запущено вне редактора, использовать стандартную функцию выхода
        Application.Quit();
#endif
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    // Список бэкгрунда
    public GameObject[] ground = new GameObject[3];

    public Vector2 BackPos = new Vector2(1920, 0);

    void Start()
    {
        Change();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change()
    {
        for (int i = 0; i < ground.Length; i++)
            Instantiate(ground[i], BackPos, Quaternion.identity);
    }


    public void ChangeScene(int _number)
    {
        SceneManager.LoadScene(_number);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}

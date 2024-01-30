using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCondition : MonoBehaviour
{
    public static bool isPressed = false;
    public GameObject PauseUI;
    
    public void resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPressed = false;
    }
    public void pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPressed = true;
    }

    public void restart()
    {
        SceneManager.LoadScene("Tutorial - Lv 1");
    }

    public void home()
    {
        SceneManager.LoadScene("Homescene");
    }



}

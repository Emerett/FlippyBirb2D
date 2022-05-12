using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Restarts the scene when the button is pressed
    public void RestartGame()
    {
        Physics2D.gravity = new Vector2(0, 3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

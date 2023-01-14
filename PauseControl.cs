using UnityEngine;

public class PauseControl : MonoBehaviour
{
    [SerializeField] Ball myBall;

    public static bool gameIsPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            Time.timeScale += 0.5f;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Time.timeScale = 1.0f;
        }

    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
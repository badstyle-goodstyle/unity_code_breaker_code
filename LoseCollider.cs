using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    Level currentLevel;

    private void Start()
    {
        currentLevel = FindObjectOfType<Level>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Bonus")
        {
            currentLevel.RemoveBall();
            if (currentLevel.GetBallsAmount() <= 0)
            {
                SceneManager.LoadScene("Game Over Scene");
            }
        }
        else if (collision.name == "Bonus")
        {
            Destroy(collision.gameObject, 1.0f);
        }
        
    }
}

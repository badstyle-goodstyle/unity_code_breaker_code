using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks = 0;
    SceneLoader loader;
    [SerializeField] TextMeshProUGUI scoretext;

    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 80;
    [SerializeField] GameObject newBall;

    int totalBalls = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<Level>().Length;
        if (gameStatusCount > 1)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        if (!newBall.activeSelf) {
            newBall.SetActive(true);
        }
    }

    private void Start()
    {
        scoretext.text = currentScore.ToString();
        loader = FindObjectOfType<SceneLoader>();
    }

    public void DoublePoints()
    {
        pointsPerBlockDestroyed *= 2;
    }

    public void AddBall()
    {
        totalBalls++;
    }

    public void RemoveBall()
    {
        totalBalls--;
    }

    public int GetBallsAmount()
    {
        return totalBalls;
    }

    public void AddBlock()
    {
        breakableBlocks++;
    }

    public void SubtractBlock() { breakableBlocks--; CheckLevelEnd(); }

    public void CheckLevelEnd()
    {
        if (breakableBlocks == 0)
        {
            loader.LoadNextScene();
        }
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoretext.text = currentScore.ToString();
    }

    public void Update()
    {
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}

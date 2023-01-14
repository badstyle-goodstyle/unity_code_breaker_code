using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraOptions : MonoBehaviour
{
    [SerializeField] GameObject secondBall;
    [SerializeField] Paddle existingPaddle;
    [SerializeField] Level currentLevel;

    IEnumerator SimpleCoroutine()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
    }

    private void Awake()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Start()
    {

    }

    public void GiveAdditionalBall()
    {
        Vector3 plusPos = new(-.5f, .5f, 0);
        Debug.Log("+1 ball");
        secondBall.SetActive(true);
        secondBall.transform.position = existingPaddle.transform.position + plusPos;
        DestroyItself();
    }

    public void DoublePoints()
    {
        currentLevel.DoublePoints();
        Debug.Log("Double points");
        
        DestroyItself();
    }

    public void DoublePaddleSize()
    {
        Vector3 plusScale = new(1.0f, 0, 0);
        Debug.Log("Double paddle size");
        existingPaddle.transform.localScale += plusScale;
        DestroyItself();
    }

    public void JustClose()
    {
        Debug.Log("Close button");
        DestroyItself();
    }

    void DestroyItself()
    {
        StartCoroutine(SimpleCoroutine());
        Time.timeScale = 3.0f;
        gameObject.SetActive(false);
    }
}

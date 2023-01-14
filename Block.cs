using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    Level level;
    // Ball ball;

    public void Start()
    {
        // ball = FindObjectOfType<Ball>();

        level = FindObjectOfType<Level>();
        level.AddBlock();
    }

    private void DestroyItself()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.SubtractBlock();
        level.AddToScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyItself();
    }
}

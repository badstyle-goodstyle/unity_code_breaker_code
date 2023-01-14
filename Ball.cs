using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Параметры конфигурации
    [SerializeField] Paddle paddle1;
    [SerializeField] float firstPushX = 2.0f;
    [SerializeField] float firstPushY = 15.0f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // Параметры состояния
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Ссылки на кэшированные ресурсы
    AudioSource myAudioSource;
    public Rigidbody2D myRigidBody;

    void Start()
    {
        paddle1 = FindObjectOfType<Paddle>();
        FindObjectOfType<Level>().AddBall();
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource= GetComponent<AudioSource>();
        myRigidBody= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    public void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToBallVector + paddlePos;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            hasStarted = true;
            myRigidBody.velocity = new Vector2(firstPushX, firstPushY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor), Random.Range(0, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody.velocity += velocityTweak;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BottomBlockCollider")
        {
            gameObject.SetActive(false);
        }
    }
}

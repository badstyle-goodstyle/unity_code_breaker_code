using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] int minX = 1;
    [SerializeField] int maxX = 15;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MovePaddle()
    {
        float mousePosX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosX, minX, maxX);
        transform.position = paddlePos;
    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();    
    }
}

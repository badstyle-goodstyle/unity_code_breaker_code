using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "Paddle")
        {
            InitializeDialogueBox();
        }
    }

    private void InitializeDialogueBox()
    {
        dialogueBox.SetActive(true);
        Destroy(gameObject);
    }
}

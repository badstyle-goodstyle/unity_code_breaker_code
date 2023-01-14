using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBonus : MonoBehaviour
{
    [SerializeField] GameObject bonusDiamond;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bonusDiamond.SetActive(true);
    }
}

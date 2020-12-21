using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriger : MonoBehaviour
{
    public GameManager gameManager;

    public void CompleteLevel()
    {
        Debug.Log("LEVEL WON");
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.CompleteLevel();

    }

}

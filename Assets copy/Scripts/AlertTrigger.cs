using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertTrigger : MonoBehaviour
{
    public GameManager gameManager;

    public void UiAlert()
    {
        Debug.Log("LEVEL WON");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.UiAlert();

    }

}

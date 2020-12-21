using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Rocket : MonoBehaviour


{
    //public int score;
    public Text scoreText;
    private Rigidbody2D rb;
    private float jumpForce = 50f;
    private bool engineIson;
    public float currentScore;
    public float pointIncPerSecond;
    private ScoreManager score;
    private int myY;
    int temp;
    private float deltaX, deltaY;
    public GameManager gameManager;


    //private bool scored;

    [SerializeField]
    private GameObject fire;


    // Start is called before the first frame update
    private void Start()
    {
       
            if (Advertisement.isSupported)
            {
                Advertisement.Initialize("3944641", false);
            }


        engineIson = false;
        fire.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        currentScore = 0f;
        pointIncPerSecond = 1f;
        score = FindObjectOfType<ScoreManager>();
        temp = myY;

    }

    // Update is called once per frame
    private void Update()
    {

        myY = Mathf.RoundToInt(transform.position.y);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            engineIson = true;
            fire.SetActive(true);
            score.scoreIncreasing = true;
            score.scoreDecreasing = false;

           
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            engineIson = false;
            fire.SetActive(false);
            if (transform.position.y < 0)
            {
                score.scoreDecreasing = false;
            }
            else
            {
                score.scoreDecreasing = true;
                score.scoreIncreasing = false;
            }

            
        }

    }


    private void FixedUpdate()
    {
        switch (engineIson)
        {
            case true:
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
                break;
            case false:
                rb.AddForce(new Vector2(0f, 0f), ForceMode2D.Force);
                break;


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            engineIson = true;
            fire.SetActive(true);
            score.scoreIncreasing = true;
            score.scoreDecreasing = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            engineIson = false;
            fire.SetActive(false);

            if (transform.position.y < 0)
            {
                score.scoreDecreasing = false;
            }
            else
            {
                score.scoreDecreasing = true;
                score.scoreIncreasing = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("video");
            }
            SceneManager.LoadScene("Game");
        }

    }

}
    

   

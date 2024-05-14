using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    //public GameObject ballPrefab;
    //public Transform blasterTransform;
    public int score = 0;
    public Button button;
    /*public Text text1;
    public Text text2;*/
    //public TextMesh scoreText; // Assign a TextMesh component to display the score

    //private bool isTriggerPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        //UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision Detected");
        print("Collided");
        // Check if the collided object is a monster
        if (other.gameObject.tag == "Monster"){
            // Destroy both the ball and the monster
            Destroy(other.gameObject);
            Destroy(gameObject);

            //update UI
            //ScoreManager.instance.StartStopwatch();

            //IncreaseScore();

            // Update the score text
            //UpdateScoreText();
        }
        /*if (other.gameObject.tag == "startGame"){
            ScoreManager.instance.StartStopwatch();
            button.gameObject.SetActive(false);
            text1.gameObject.SetActive(true);
            text2.gameObject.SetActive(true);
        }*/
    }

    /*void IncreaseScore()
    {
        score++;
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }*/
}

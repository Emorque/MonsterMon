using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform blasterTransform;
    public int score = 0;
    public TextMesh scoreText; // Assign a TextMesh component to display the score

    private bool isTriggerPressed = false;

    void Start()
    {
        //UpdateScoreText();
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)){
            if (!isTriggerPressed){
                GameObject newBall = Instantiate(ballPrefab, blasterTransform.position, blasterTransform.rotation);
                newBall.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                Destroy(newBall, 4);

                isTriggerPressed = true;
            }
        }
        else {
            isTriggerPressed = false;
        }

        /*if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if (!isTriggerPressed)
            {
                StartCoroutine(ShootBall());
                isTriggerPressed = true;
            }
        }
        else
        {
            isTriggerPressed = false;
        }*/
    }

    /*IEnumerator ShootBall()
    {
        GameObject ball = Instantiate(ballPrefab, blasterTransform.position, blasterTransform.rotation);
        ball.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        Destroy(ball, 4);
        yield return new WaitForSeconds(3f);

    }*/

    /*void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is a monster
        if (other.CompareTag("Monster"))
        {
            // Destroy both the ball and the monster
            Destroy(other.gameObject);
            IncreaseScore();

            // Update the score text
            UpdateScoreText();
        }
    }

    void IncreaseScore()
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

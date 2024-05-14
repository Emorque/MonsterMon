using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private float currentTime;
    private bool isRunning = false;

    public Text stopwatchText;
    public Text numMonstersText;
    public Text startButton;
    public long numMonsters;

    private void Awake(){
        instance = this;
    }
    void Update()
    {
        if (isRunning)
        {
            if (NoMoreGameObjectsWithTag("Monster")){
                StopStopwatch();
            }
            numMonsters = numberOfMonsters("Monster");
            numMonstersText.text = string.Format("Monsters Left: {0}",  numMonsters);
            currentTime += Time.deltaTime;
            UpdateStopwatchDisplay();
            
        }
        if (numberOfMonsters("Monster") > 0){
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch)) // Check for the "A" button
            {
                startButton.gameObject.SetActive(false);
                StartStopwatch();
            }
        }
        
        
        if (numberOfMonsters("Monster") == 0){
            startButton.gameObject.SetActive(true);
            startButton.text = "Great Job, reset your game with B";
            if (OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch)){
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }
        }
    }
    bool NoMoreGameObjectsWithTag(string tag)
    {
        // Find all GameObjects with the specified tag
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

        // Check if the array is empty
        return gameObjects.Length == 0;
    }

    long numberOfMonsters(string tag){
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        return gameObjects.LongLength;
    }
    void UpdateStopwatchDisplay()
    {
        // Convert time to minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        int milliseconds = Mathf.FloorToInt((currentTime * 1000) % 1000);

        // Update the text on the Text object
        stopwatchText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }

    public void StartStopwatch()
    {
        isRunning = true;
    }

    public void StopStopwatch()
    {
        isRunning = false;
    }

    public void ResetStopwatch()
    {
        currentTime = 0f;
        UpdateStopwatchDisplay();
    }
}

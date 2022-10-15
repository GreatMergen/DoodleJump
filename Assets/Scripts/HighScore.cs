using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public float highScore;
    public float currentScore;
    public static HighScore Instance;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        currentScore = Mathf.Clamp(currentScore, transform.position.y, currentScore);
        currentScore = Convert.ToInt32(currentScore);
    }

    //Save ve load score burada yazılacak. Load Startta save gamemanager da çağrılacak.

    public void SaveHighScore()
    {
        if(currentScore > highScore)
        {
           PlayerPrefs.SetFloat("HighScore", currentScore);
        }
   
    }

    public void LoadHighScore()
    {
      highScore = PlayerPrefs.GetFloat("HighScore", highScore);

      print(highScore);
    }
}

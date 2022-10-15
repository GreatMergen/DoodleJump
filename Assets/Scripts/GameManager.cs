using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Rigidbody2D rb;


    private void Awake()
    {
        GetIntance();

    }
    private void Start()
    {
        rb =  GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    private void GetIntance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void OnDeath()
    {
        HighScore.Instance.SaveHighScore();
        UIManager.Instance.GameOverScreen();
        
    }




}
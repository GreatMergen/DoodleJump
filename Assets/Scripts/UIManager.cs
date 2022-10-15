using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public static UIManager Instance;
    public GameObject startImage;
    public GameObject startMenuCanvas;

    Tween tween;
    private void Awake()
    {
        GetIntance();
        
      tween = startImage.GetComponent<RectTransform>().transform.DOScale(5, 1f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InSine);

    }
    void Start()
    {
        startMenuCanvas.SetActive(true);
        highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();

        
    }

    private void GetIntance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

   
    void Update()
    {
        currentScoreText.text = HighScore.Instance.currentScore.ToString();
    }

    public void GameOverScreen()
    {
        highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
        startMenuCanvas.SetActive(true);
        tween.Play();
    }

    public void OpenYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCky2ZiAeSBE3RAKAUyUvJ-g");
    }

    public void StartButton()
    {
        startMenuCanvas.SetActive(false);
        GameManager.Instance.rb.gravityScale = 1;
        tween.Kill();
    }
}

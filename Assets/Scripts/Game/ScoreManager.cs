using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Obj { get; private set; }

    [SerializeField] Text scoreOnScreen;
    public int score;
    [SerializeField] Text highscore;

    AudioSource audioS;

    void Awake()
    {
        if (Obj != null && Obj != this)
            Destroy(this);
        else
            Obj = this;
    }

    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("Score", 0).ToString();
        audioS = GetComponent<AudioSource>();
    }

    public void addScore(int giveScore)
    {
        score += giveScore;
        updateScore();
    }

    public void updateScore()
    {
        scoreOnScreen.text = "" + score;
        audioS.Play();
    }

    public void highScore()
    {
        if (score > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
            highscore.text = score.ToString();
        }
    }
}
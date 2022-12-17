using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Obj { get; private set; }

    [SerializeField] Text scoreOnScreen;
    public int score;

    void Awake()
    {
        if (Obj != null && Obj != this)
            Destroy(this);
        else
            Obj = this;
    }

    public void addScore(int giveScore)
    {
        score += giveScore;
        updateScore();
    }

    public void updateScore()
    {
        scoreOnScreen.text = "" + score;
    }
}

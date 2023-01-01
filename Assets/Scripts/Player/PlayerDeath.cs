using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Transform playerExplotionPosition;

    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject DeadPanel;

    [SerializeField] GameObject player;
    [SerializeField] GameObject playerHealth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerDied();
    }

    void OnEnable()
    {
        Invoke("GameToStop", 2.5f);
    }

    public void PlayerDied()
    {
        PlayerSecondShot.Obj.ExplotionAndDie();

        spriteRenderer.enabled = false;

        player.GetComponent<PlayerMovment>().enabled = false;
        playerHealth.GetComponent<Canvas>().enabled = false;   

        GameObject explosion = PoolManager.Obj.ExplotionPool.GetElement();
        ExplotionBehaviour explotionBehaviour = explosion.GetComponent<ExplotionBehaviour>();
        explotionBehaviour.SetUpExplotion(playerExplotionPosition.position);
    }

    void GameToStop()
    {
        DeadPanel.SetActive(true);
        Time.timeScale = 0f;
        ScoreManager.Obj.highScore();
    }
}
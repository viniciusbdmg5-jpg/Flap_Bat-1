using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Score scoreScript;

    private int level = 0;

    private void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("GameController")
        .GetComponent<Score>();
    }

    private void Update()
    {
        if (PlayerController.Instance.gameStarted && !GameOver.instance.IsGameOver)
        {
            level = scoreScript.GanhaLevel();
            speed = 5f + level;

            transform.position +=
                Vector3.left * speed * Time.deltaTime;

            if (transform.position.x < -15f)
            {
                Destroy(gameObject);
            }

        }
    }







}
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    private float score = 0f;
    [SerializeField] private TextMeshProUGUI scoreText;

    //Aumentar a dificuldade
    private int level = 1;
    private float proximoLevel = 10f;


    public GameObject background;
    public Material[] backgroundMaterials;
    private int ultimoLevel = 1;

    void Update()
    {
        if (PlayerController.Instance.gameStarted && !GameOver.instance.IsGameOver)
        {
            sistemaPontos();


            if (level > ultimoLevel)
            {
                TrocarBackground();
                ultimoLevel = level;
            }
        }

    }

    private void sistemaPontos()
    {
        score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public int GanhaLevel()
    {
        if (score >= proximoLevel)
        {
            level++;
            proximoLevel += 10f;
        }
        return level;
    }

    private void TrocarBackground()
    {
        if (backgroundMaterials.Length > (level - 1))
        {
            background.GetComponent<Renderer>().material =
                backgroundMaterials[level - 1];
        }
    }
    }
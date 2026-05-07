using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    public static GameOver instance {  get; private set; }
    public static object Instance { get; internal set; }

    public bool IsGameOver = false;
    public TextMeshProUGUI textoGameOver;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void MetodoGameOver(string texto){
        IsGameOver = true;
        textoGameOver.gameObject.SetActive(true);
        textoGameOver.text = texto;
    }
}

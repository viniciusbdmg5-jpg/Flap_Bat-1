using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject obstaclePrefab;//Objstaculo que vai ser spawnado
    public float spawnInterval = 2f;//Intervalo entre cada spawn
    public Vector3 spawnPosition = new Vector3(14f, -2f, 0f);//Posição aonde ele vai ser spawnado
    private float timer;//Contador do intervalo

    public float maximumY = 2.6f;
    public float minimumY = -2.6f;

    private void Update()
    {
        if (PlayerController.Instance.gameStarted && !GameOver.instance.IsGameOver)
        {
            timer -= Time.deltaTime;//Contador do intervalo
            if (timer <= 0f)
            {
                SpawnObstacle();//Método logo abaixo
                timer = spawnInterval;//Reseta o contador
            }

        }
    }

    void SpawnObstacle()
    {
        spawnPosition.y = Random.Range(minimumY, maximumY);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);//Instancia o obstáculo na posição definida
    }
}

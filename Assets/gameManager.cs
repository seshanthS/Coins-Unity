using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    private bool hasEnded = false;
    public Text scoreBoard;
    public Button pauseButton;
    public bool isPaused = false;

    public GameObject obstacle;
    public GameObject coin;

    float spawnRandomX, spawnRandomY, spawnRandomZ;
    public float timer = 8f;
    public float coinSpawnTimer = 4f;
    GameObject[] pausedGameObject;
    float score;
    // Start is called before the first frame update
    void Start()
    {
        pausedGameObject = GameObject.FindGameObjectsWithTag("PauseScreen");
        foreach(GameObject gameObject in pausedGameObject)
        {
            gameObject.SetActive(false);
        }
        spawnCoin();
        for (int i = 0; i < 8; i++)
        {
            spawnRandomObstacles();
        }

    }
     
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        coinSpawnTimer -= Time.deltaTime;
        if (coinSpawnTimer <= 0)
        {
            spawnCoin();
            coinSpawnTimer = 4f;
        }
        if(timer <= 0)
        {
            spawnRandomObstacles();
            timer = 8f;
        }

        //pauseGame when ESC key is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }


        //if (Input.GetKey(KeyCode.Mouse0))
        //{
          //  spawnRandomObstacles(1);
        //}
    }

    public void PauseGame()
    {
        if (isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0;
            foreach (GameObject gameObject in pausedGameObject)
            {
                gameObject.SetActive(true);

            }
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            foreach (GameObject gameObject in pausedGameObject)
            {
                gameObject.SetActive(false);

            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("IntroScene");
    }

    void spawnCoin()
    {
        
        spawnRandomX = Random.Range(-32, 32);
        spawnRandomZ = Random.Range(-32, 32);
        Instantiate(coin, new Vector3(spawnRandomX, 10, spawnRandomZ), Quaternion.identity);
        
    }

    void spawnRandomObstacles()//int count)
    {
        //for(int i = 0; i< count; i++)
        //{
        //int count = Random.Range(3, 5);
        //for (int i = 0; i < count; i++)
        //{
            Debug.Log("spawning Obstacle");
            spawnRandomX = Random.Range(-32, 32);
            spawnRandomZ = Random.Range(-32, 32);
            Instantiate(obstacle, new Vector3(spawnRandomX, 30, spawnRandomZ), Quaternion.identity);
        //}
    }

    public void UpdateScore(float _score)
    {
        score += _score;
        scoreBoard.text = "score: " + score;
        Debug.Log(score);
    }

    public void EndGame()
    {
        if(hasEnded == false)
        {
            hasEnded = true;
            Invoke("RestartLevel", 2f);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

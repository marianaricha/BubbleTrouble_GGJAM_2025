using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public float velocityBoost;
    public int points;

    
    void Awake()
    {
        if(Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);

        NewGame();
    }

    public void NewGame(){
        velocityBoost = 1;
        points = 0;
    }

    public void SetNewPoints(int pointsGained){
        points += pointsGained;
        Debug.Log(points);
    }

    public void UpVelocityBoost(){
        velocityBoost *= (float)1.1;
    }

    public void LoadNextLevel(){
        SceneManager.LoadScene(Random.Range(2, 4)); // mudar o range quando adicionar cena de menu (menu = 0, gameOver = 1, jogos >= 2)
    }

    public void GameOver(){
        SceneManager.LoadScene(1); // cena GameOver
    }
}

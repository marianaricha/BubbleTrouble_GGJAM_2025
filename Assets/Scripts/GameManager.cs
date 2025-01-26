using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using MaskTransitions;

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
        MusicManager.Instance.SpeedUpMusic();
    }

    public void SetNewPoints(int pointsGained){
        points += pointsGained;
        Debug.Log(points);
    }

    public void UpVelocityBoost(){
        velocityBoost *= (float)1.1;
        MusicManager.Instance.SpeedUpMusic();
    }

    public void LoadNextLevel(){
        TransitionManager.Instance.LoadLevel(GetSceneName(Random.Range(2, 4))); // mudar o range quando adicionar cena de menu (menu = 0, gameOver = 1, jogos >= 2)
    }

    public void GameOver(){
        TransitionManager.Instance.LoadLevel(GetSceneName(1)); // cena GameOver
    }

    public static string GetSceneName(int buildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(buildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
}

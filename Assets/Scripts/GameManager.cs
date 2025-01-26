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
    private List<int> buildIndexList;

    
    void Awake()
    {
        if(Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);

        NewGame();
        buildIndexList = GenerateIntegerList(2,5);
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
        if(buildIndexList.Count == 0){
            buildIndexList = GenerateIntegerList(2, 5);
        }
        TransitionManager.Instance.LoadLevel(GetSceneName(buildIndexList[0])); // mudar o range quando adicionar cena de menu (menu = 0, gameOver = 1, jogos >= 2)
        buildIndexList.RemoveAt(0);
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

    public List<int> GenerateIntegerList(int min, int max)
    {
        List < int > list = new List<int>();
        for (int i = min; i <= max; i++)
        {
            list.Add(i);
        }
        return ShuffleListWithOrderBy(list);
    }

    public List<int> ShuffleListWithOrderBy(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (list[j], list[i]) = (list[i], list[j]);
        }
        return list;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
        private TextMeshProUGUI score;
    void Start()
    {
        if(score){
            score.text = GameManager.Instance.points.ToString();
        }
    }

    public void StartGame(){
        GameManager.Instance.NewGame();
        GameManager.Instance.LoadNextLevel();
    }

    public void QuitGame(){
        Application.Quit();
    }
}

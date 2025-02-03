using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SocialBubbleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Friends;
    private float timer;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI Title;
    //private SocialFriendsController friendsController;
    public TextMeshProUGUI Contador;
    private bool isFinished = false;
    private float velocityBoost;

    void Start()
    {
        velocityBoost = GameManager.Instance.velocityBoost;
        Title.gameObject.SetActive(true);
        SocialBubbleCounter.Instance.AtualizarTexto();
        Contador.gameObject.SetActive(true);
        timer = 20f/velocityBoost;
        if(timer <= 5) timer = 5f;
    }
    // Update is called once per frame
    void Update()
    {
        if(!isFinished){
            CountDown();
        }
    }
    private void CountDown(){
        timer -= Time.deltaTime;
        Debug.Log(timer);
        timerText.text = Mathf.FloorToInt(timer).ToString();

        if(SocialBubbleCounter.Instance.Cont >= 10){
            //timerText.text = "0";
            isFinished = true;
            GameManager.Instance.SetNewPoints(1000);
            GameManager.Instance.UpVelocityBoost();
            GameManager.Instance.LoadNextLevel();
        }
        if(timer <= 0){

            timerText.text = "0";
            isFinished = true;
            if(SocialBubbleCounter.Instance.Cont < 10){
                GameManager.Instance.GameOver();
            }else{
                GameManager.Instance.SetNewPoints(1000);
                GameManager.Instance.UpVelocityBoost();
                GameManager.Instance.LoadNextLevel();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleGumManager : MonoBehaviour
{
    private Vector3 scaleChange;
    public GameObject bubbleGum;
    public GameObject girl;
    public GameObject girlPopped;
    public GameObject bubbleGumPop;
    public TextMeshProUGUI timerText;
    private bool isFinished = false;
    public GameObject yaaayText;
    private float timer;
    private float velocityBoost;

    // Start is called before the first frame update
    void Awake()
    {
        scaleChange = new Vector3(5f, 5f, 5f);
        velocityBoost = GameManager.Instance.velocityBoost;
        timer = 20f/velocityBoost;
        girlPopped.SetActive(false);
        bubbleGumPop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFinished){
            CountDown();
        }

        if(Input.GetMouseButtonDown(0) && !isFinished){
            bubbleGum.transform.localScale += scaleChange;
            CheckBubbleSize();
        }

    }

    private void CountDown(){
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F0");

        if(timer <= 0){
            timerText.text = "0";
            isFinished = true;
            girl.SetActive(false);
            bubbleGum.SetActive(false);
            girlPopped.SetActive(true);
            bubbleGumPop.SetActive(true);
            GameManager.Instance.GameOver();
        }
    }

    private void CheckBubbleSize(){
        if(bubbleGum.transform.localScale == new Vector3(150, 150, 150) && timer > 0){
            isFinished = true;
            yaaayText.SetActive(true);
            GameManager.Instance.SetNewPoints(1000 + (int)timer*100);
            GameManager.Instance.UpVelocityBoost();
            GameManager.Instance.LoadNextLevel();
            girl.SetActive(false);
            bubbleGum.SetActive(false);
            girlPopped.SetActive(true);
            bubbleGumPop.SetActive(true);
            
        }
    }
}

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
    public TextMeshProUGUI timerText;
    private bool isFinished = false;
    public GameObject yaaayText;
    private float timer;
    private float velocityBoost;

    // Start is called before the first frame update
    void Awake()
    {
        scaleChange = new Vector3(0.04f, 0.04f, 0.04f);
        velocityBoost = GameManager.Instance.velocityBoost;
        timer = 20f/velocityBoost;
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
            girlPopped.SetActive(true);
        }
    }

    private void CheckBubbleSize(){
        if(bubbleGum.transform.localScale == new Vector3(4, 4, 4) && timer > 0){
            isFinished = true;
            yaaayText.SetActive(true);
            GameManager.Instance.SetNewPoints(1000 + (int)timer*100);
            GameManager.Instance.UpVelocityBoost();
            GameManager.Instance.LoadNextLevel();
        }
    }
}

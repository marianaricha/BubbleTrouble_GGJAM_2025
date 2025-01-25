using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnorePopManager : MonoBehaviour
{
    public GameObject snoreBubble;
    public GameObject guy;
    public GameObject guyFallen;
    public TextMeshProUGUI timerText;
    private bool isFinished = false;
    public GameObject yaaayText;
    private float timer;
    private float velocityBoost;

    void Start()
    {
        velocityBoost = GameManager.Instance.velocityBoost;
        timer = 10f/velocityBoost;
    }

    void Update()
    {
        if(!isFinished){
            CountDown();
        }

        if (Input.GetMouseButtonDown(0)) {
             CastRay();
        }  


    }
    void CastRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider !=null) {

            Debug.Log ("CLICKED " + hit.collider.name);
            isFinished = true;
            snoreBubble.SetActive(false);
            guy.SetActive(false);
            guyFallen.SetActive(true);
            
        }
    }

    private void CountDown(){
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F0");

        if(timer <= 0){
            timerText.text = "0";
            isFinished = true;
            yaaayText.SetActive(true);
            GameManager.Instance.SetNewPoints(1000);
            GameManager.Instance.UpVelocityBoost();
            GameManager.Instance.LoadNextLevel();
        }
    }
}

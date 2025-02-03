using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubblePopBehavior : MonoBehaviour
{    
    [SerializeField] private GameObject bubblePrefab;
    private ObjectPool bubblePool;
    [SerializeField] private GameObject ouricoPrefab;
    private ObjectPool ouricoPool;
    private bool isFinished = false;
    public float tempoDecorrido = 0;
    private float timer = 15;
    private float velocityBoost;
    public TextMeshProUGUI timerText;
    public float speed = 10f;

    public static BubblePopBehavior Instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        velocityBoost = GameManager.Instance.velocityBoost;
        speed = speed * velocityBoost;
        bubblePool = new ObjectPool(bubblePrefab, 15); 
        ouricoPool = new ObjectPool(ouricoPrefab, 5);    
    }

    // Update is called once per frame
    void Update()
    {
        tempoDecorrido += Time.deltaTime;
        int rand;

        if (PlayerPrefs.GetInt("GameOver") == 1){
            bubblePool.ResetPool();
            ouricoPool.ResetPool();
            print("Reset Pools");
            PlayerPrefs.SetInt("GameOver", 0);
        }

        if(tempoDecorrido >= 1){
            rand = Random.Range(0, 4);
            if(rand == 0)
                Ourico();  
                else Bubble();
            tempoDecorrido = 0;
        }
        
        if(!isFinished){
            CountDown();
        }

    }

    void Ourico(){
        GameObject ourico = ouricoPool.GetFromPool();
        
        float x = Random.Range(-2,2);
        Vector3 vector3 = new Vector3(x, -5, 1);

        ourico.transform.position = (vector3);
    }
    void Bubble()
    {
        GameObject bubble = bubblePool.GetFromPool();
        
        float x = Random.Range(-2,2);
        Vector3 vector3 = new Vector3(x, -5, 1);

        bubble.transform.position = (vector3);
    }

    private void CountDown(){
        timer -= Time.deltaTime;
        timerText.text = Mathf.FloorToInt(timer).ToString();

        if(timer <= 0){
            timerText.text = "0";
            isFinished = true;
            bubblePool.ResetPool();
            ouricoPool.ResetPool();
            GameManager.Instance.SetNewPoints(1000 + (int)timer*100);
            GameManager.Instance.UpVelocityBoost();
            GameManager.Instance.LoadNextLevel();
        }


    }
}

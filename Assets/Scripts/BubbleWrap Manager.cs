using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleWrapManager : MonoBehaviour
{
    public GameObject bubblePrefab;
    public RectTransform parentTransform;
    public int rows = 5;
    public int columns = 4;
    public float columnSpacing = 80f;
    public float lineSpacing = 120f;
    public int initialPoppedBubbles = 5; 
    private bool isFinished = false;
    private List<GameObject> bubbles = new List<GameObject>();
    private float timer;
    private float velocityBoost;
    public TextMeshProUGUI timerText;


    void Awake()
    {
        // if(velocityBoost <= 0)
        // {
        //     velocityBoost = 1f;
        // }
        GenerateBubbles();
        PopRandomBubbles();
        velocityBoost = GameManager.Instance.velocityBoost;
        timer = 30f/velocityBoost;
        if(timer <= 10) timer = 10f;
    }

    void Update()
    {
        if(!isFinished)
        {
            CountDown();
            CheckAllBubblesPopped();
        }
    }
    void GenerateBubbles()
    {
        RectTransform parentRect = parentTransform.GetComponent<RectTransform>();
        Vector2 bubbleSize = bubblePrefab.GetComponent<RectTransform>().sizeDelta;

        float totalWidth = columns * bubbleSize.x + (columns - 1) * columnSpacing;
        float totalHeight = rows * bubbleSize.y + (rows - 1) * lineSpacing;

        float startX = -totalWidth / 2f + bubbleSize.x / 2f;
        float startY = totalHeight / 2f - bubbleSize.y / 2f;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject bubble = Instantiate(bubblePrefab, parentTransform);
                RectTransform rect = bubble.GetComponent<RectTransform>();

                float x = startX + j * (bubbleSize.x + columnSpacing);
                float y = startY - i * (bubbleSize.y + lineSpacing);

                rect.anchoredPosition = new Vector2(x, y);

                bubbles.Add(bubble);
            }
        }
    }


    void PopRandomBubbles()
    {
        int bubblesToPop = Mathf.Min(initialPoppedBubbles, bubbles.Count);
        List<int> randomIndexes = new List<int>();

        while (randomIndexes.Count < bubblesToPop)
        {
            int randomIndex = Random.Range(0, bubbles.Count);
            if (!randomIndexes.Contains(randomIndex))
            {
                randomIndexes.Add(randomIndex);
                bubbles[randomIndex].GetComponent<Bubble>().ForcePop();
            }
        }
    }

    private void CountDown(){
        timer -= Time.deltaTime;
        timerText.text = Mathf.FloorToInt(timer).ToString();

        if(timer <= 0){
            timerText.text = "0";
            isFinished = true;
            GameManager.Instance.GameOver();
        }
    }

    private void CheckAllBubblesPopped()
    {
        bool allPopped = true;

        foreach (var bubble in bubbles)
        {
            if(!bubble.GetComponent<Bubble>().isPopped)
            {
                allPopped = false;
                break;
            }
        }

        if(allPopped)
        {
            isFinished = true;
            GameManager.Instance.SetNewPoints(1000 + (int)timer*100);
            GameManager.Instance.UpVelocityBoost();
            GameManager.Instance.LoadNextLevel();
        }
    }
}
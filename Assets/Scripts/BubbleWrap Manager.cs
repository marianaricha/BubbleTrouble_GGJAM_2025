using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleWrapManager : MonoBehaviour
{
    public GameObject bubblePrefab;
    public RectTransform parentTransform;
    public int rows = 5;
    public int columns = 5;
    public float spacing = 10f;
    public int initialPoppedBubbles = 5; 
    private List<GameObject> bubbles = new List<GameObject>();

    void Start()
    {
        GenerateBubbles();
        PopRandomBubbles();
    }

void GenerateBubbles()
{
    RectTransform parentRect = parentTransform.GetComponent<RectTransform>();
    Vector2 bubbleSize = bubblePrefab.GetComponent<RectTransform>().sizeDelta;

    float totalWidth = columns * bubbleSize.x + (columns - 1) * spacing;
    float totalHeight = rows * bubbleSize.y + (rows - 1) * spacing;

    float startX = -totalWidth / 2f + bubbleSize.x / 2f;
    float startY = totalHeight / 2f - bubbleSize.y / 2f;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            GameObject bubble = Instantiate(bubblePrefab, parentTransform);
            RectTransform rect = bubble.GetComponent<RectTransform>();

            float x = startX + j * (bubbleSize.x + spacing);
            float y = startY - i * (bubbleSize.y + spacing);

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
}

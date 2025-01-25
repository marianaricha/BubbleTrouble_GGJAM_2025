using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public Color poppedColor = Color.gray;
    private Image bubbleImage;
    private bool isPopped = false;

    void Start()
    {
        bubbleImage = GetComponent<Image>();
        var button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(PopBubble);
    }

    public void PopBubble()
    {
        if (isPopped) return;

        isPopped = true;
        bubbleImage.color = poppedColor;
    }

    public void ForcePop()
    {
        if (isPopped) return;

        isPopped = true;
        if (bubbleImage == null)
        {
            bubbleImage = GetComponent<Image>();
        }
        bubbleImage.color = poppedColor;
    }
}

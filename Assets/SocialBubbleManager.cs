using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SocialBubbleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Friends;
    public TextMeshProUGUI Title;
    private BubbleCounter bubbleCounter;
    private FriendsController friendsController;
    public TextMeshProUGUI Contador;
    void Start()
    {
        ShowTitle();
        ShowCount();
    }
    void ShowCount(){
        bubbleCounter.AtualizarTexto();
        Contador.gameObject.SetActive(true);

    }
    void ShowTitle(){
        Title.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SocialBubbleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Friends;
    public TextMeshProUGUI Title;
    private FriendsController friendsController;
    public TextMeshProUGUI Contador;
    void Start()
    {
        ShowTitle();
        HideCount();
        //Invoke("HideFriends", 1f);
        Invoke("HideTitle", 1.5f);
        Invoke("ShowCount", 1.6f);
        //Invoke("ShowFriends", 2.3f);
    }
    void ShowCount(){
        Contador.gameObject.SetActive(true);
    }
    void HideCount(){
        Contador.gameObject.SetActive(false);
    }
    void ShowTitle(){
        Title.gameObject.SetActive(true);
    }
    void HideTitle(){
        Title.gameObject.SetActive(false);
    }
    void HideFriends(){
        Friends.gameObject.SetActive(false);
    }
    void ShowFriends(){
        Friends.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

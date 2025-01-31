using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendPrefabController : MonoBehaviour
{   
    //public GameObject SocialBubble;
    public GameObject friendGameObject;
    private int ContCollider = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Numero de colisões: " + ContCollider);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        friendGameObject.SetActive(false);
        ContCollider+=1;
        Debug.Log("Colisões: " + ContCollider);
    }
}

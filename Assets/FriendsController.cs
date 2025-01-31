using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsController : MonoBehaviour
{
    public ObjectPool objectPoolFriends;
    public GameObject SocialBubble;
    private SocialBubbleController socialBubbleController;

    // Start is called before the first frame update
    void Start()
    {
        objectPoolFriends = new ObjectPool(Friends, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

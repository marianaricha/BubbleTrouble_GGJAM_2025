using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsController : MonoBehaviour
{
    public bool dentroDaBolha = false;
    public ObjectPool objectPoolFriends;
    public int quantidadeFriends = 10;
    public GameObject SocialBubble;
    public GameObject Friends;
    private SocialBubbleController socialBubbleController;

    private float areaX = -6f;
    private float areaY = -19f;
    private float areaYY = 16f;

    // Start is called before the first frame update
    void Start()
    {
        objectPoolFriends = new ObjectPool(Friends, quantidadeFriends);
        for (int i = 0; i < quantidadeFriends; i++){
            randomFriend();
        }
    }

    // Update is called once per frame
    void Update()
    {
        objectPoolFriends.GetFromPool();
        if(dentroDaBolha)
        {
            //Friends.transform.position = SocialBubble.transform.position;
            float distancia = Vector3.Distance(SocialBubble.transform.position, Friends.transform.position);
            if(distancia > socialBubbleController.raioMaximo)
            {
                Vector3 direcao = (SocialBubble.transform.position - Friends.transform.position).normalized;
                Friends.transform.position += direcao * Time.deltaTime * socialBubbleController.speed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        dentroDaBolha = true;
    }
    private void randomFriend(){
        GameObject friend = objectPoolFriends.GetFromPool();
        if (friend != null){
            float randomX = Random.Range(-areaX, areaX);
            float randomY = Random.Range(areaY, areaYY);
            Vector3 friendPosition = new Vector3(randomX, randomY, 0);

            friend.transform.position = friendPosition;
            friend.SetActive(true);
        }
    }
}

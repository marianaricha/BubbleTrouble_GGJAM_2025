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

    private float areaXPositiva = 9f;
    private float areaXNegativa = -12f;
    private float areaYPositiva = 6f;
    private float areaYNegativa = -6f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("FriendsController rodando");
        objectPoolFriends = new ObjectPool(Friends, quantidadeFriends);
        for (int i = 0; i < quantidadeFriends; i++){
            randomFriend();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //objectPoolFriends.GetFromPool();
    }
    private void randomFriend(){
        GameObject friend = objectPoolFriends.GetFromPool();
        if (friend != null){
            float randomX = Random.Range(areaXNegativa, areaXPositiva);
            float randomY = Random.Range(areaYNegativa, areaYPositiva);
            Vector3 friendPosition = new Vector3(randomX, randomY, 0);

            friend.transform.position = friendPosition;
            friend.SetActive(false);

            StartCoroutine(ActivateAfterDelay(friend, 1.5f));
        }
    }
    IEnumerator ActivateAfterDelay(GameObject friend, float delay)
    {
        yield return new WaitForSeconds(delay);
        friend.SetActive(true);
    }
}

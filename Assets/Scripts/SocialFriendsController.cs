using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialFriendsController : MonoBehaviour
{
    private ObjectPool objectPoolFriends;
    private int quantidadeFriends = 10;
    public GameObject SocialBubble;
    public GameObject Friends;

    private float x = 8, y = 6;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("FriendsController rodando");
        objectPoolFriends = new ObjectPool(Friends, quantidadeFriends);
        objectPoolFriends.ResetPool();
        for (int i = 0; i < quantidadeFriends; i++){
            randomFriend();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void randomFriend(){
        GameObject friend = objectPoolFriends.GetFromPool();
        if (friend != null){
            float randomX = Random.Range(-x, x);
            float randomY = Random.Range(-y, y);
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

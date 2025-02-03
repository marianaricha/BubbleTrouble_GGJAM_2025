using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialFriendPrefabController : MonoBehaviour
{   
    public GameObject friendGameObject;
    public  int foiContado = 1;
    //Tive que colocar como int o foiContado,
    //pois alguma parte da unity o transformava em true no inicio do jogo
    //mesmo eu tentando encapsular a variável
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("FriendPrefabController rodando");
        foiContado = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bubble"){
            friendGameObject.SetActive(false);
        }
        
    }
}

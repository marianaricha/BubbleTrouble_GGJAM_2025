using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SocialBubbleCounter : MonoBehaviour
{
    public int Cont;
    public static SocialBubbleCounter Instance;
    private List<GameObject> friends = new List<GameObject>();
    public TextMeshProUGUI Contador;

    void Awake()
    {
        Instance = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        Invoke("LoadingFriends", 1.7f);
        Cont = 0;
    }
    void LoadingFriends()
    {
        friends.AddRange(GameObject.FindGameObjectsWithTag("Friends"));

        Debug.Log("Número de amigos na lista: " + friends.Count);
    }
    // Update is called once per frame
    void Update()
    {

        for(int i=0; i<friends.Count; i++){

            SocialFriendPrefabController friend = friends[i].GetComponent<SocialFriendPrefabController>();
            if(friend.foiContado == 1 && !friends[i].gameObject.activeSelf){

                Cont += 1;
                friend.foiContado = 2;
                AtualizarTexto();
            }
        }
    }
    public void AtualizarTexto()
    {
        if (Contador != null)
        {
            Contador.text = "Quantidade de Amigos feitos: " + Cont;
            Debug.Log("Atualizou texto");
        }
    }
}

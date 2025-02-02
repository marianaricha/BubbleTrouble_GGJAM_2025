using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BubbleCounter : MonoBehaviour
{
    public int Cont;
    public List<GameObject> friends = new List<GameObject>();
    public TextMeshProUGUI Contador;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        //LoadingFriends();
        Invoke("LoadingFriends", 1.7f);
        //Invoke("ShowCount", 2.3f);
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
        Debug.Log($"[BubbleCounter] Número de amigos na lista: {friends.Count}");
        for(int i=0; i<friends.Count; i++){
            Debug.Log("Entrando no for");
            FriendPrefabController friend = friends[i].GetComponent<FriendPrefabController>();
            if(friend.foiContado == 1 && !friends[i].gameObject.activeSelf){
                Debug.Log("Entrou no if");
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

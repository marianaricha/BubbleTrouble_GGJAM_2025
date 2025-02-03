
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialCamController : MonoBehaviour{
    private float speed = 4.75f;
    private float minX = 6, minY = 2;

    public Transform personagem;

    void Update(){
        Vector3 newPos = transform.position;
        if(personagem.transform.position.x < -minX && personagem.transform.position.y < -minY){
            //baixo esquerda
           newPos = new Vector3(-minX, -minY, -10f);
            
        }else 
            if(personagem.transform.position.x < -minX && personagem.transform.position.y > minY){
            //cima esquerda
           newPos = new Vector3(-minX, minY, -10f);
            
        }else 
            if(personagem.transform.position.x > minX && personagem.transform.position.y < -minY){
            //baixo direita
           newPos = new Vector3(minX, -minY, -10f);
            
        }else 
            if(personagem.transform.position.x > minX && personagem.transform.position.y > minY){
            //cima direita
           newPos = new Vector3(minX, minY, -10f);
            
        }else 
            if(personagem.transform.position.x < -minX){
           newPos = new Vector3(-minX, personagem.position.y, -10f);
            
        }else
            if(personagem.transform.position.x > minX){
           newPos = new Vector3(minX, personagem.position.y, -10f);
            
        }else 
            if(personagem.transform.position.y > minY){
           newPos = new Vector3(personagem.position.x, minY, -10f);
            
        }else 
            if(personagem.transform.position.y < -minY){
           newPos = new Vector3(personagem.position.x, -minY, -10f);
            
        }else{
           newPos = new Vector3(personagem.position.x, personagem.position.y, -10f);
            
        }
        transform.position = Vector3.Slerp(transform.position, newPos, speed * Time.deltaTime);
    }
}


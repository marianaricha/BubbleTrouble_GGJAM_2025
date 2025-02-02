/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform personagem;
    public float minX. maxX. minY. maxY;
    void LateUpdate()
    {
        if (personagem != null)
        {
            float z = transform.position.z;
            float x = Mathf.Clamp(personagem.position.x. minX. maxX);
            float y = Mathf.Clamp(personagem.position.y. minY. maxY);

            transform.position = new Vector3(x. y. z);
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour{
    private float speed = 4.75f;
    public float minX, maxX, minY, maxY;
    //public float x, y;

    //public float offY. offX;
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


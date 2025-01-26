using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuricoController: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        float dy  = BubblePopBehavior.Instance.speed * Time.deltaTime; 
        transform.Translate(0, dy, 0); 

        if(transform.position.y > 5){
            gameObject.SetActive(false);
        }

    }

    void OnMouseDown() {
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("GameOver",1);
        GameManager.Instance.GameOver();
    }
    
}
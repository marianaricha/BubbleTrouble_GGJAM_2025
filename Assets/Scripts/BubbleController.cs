using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController: MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float dy  = BubblePopBehavior.Instance.speed * Time.deltaTime; 
        transform.Translate(0, dy, 0); 

        if(transform.position.y > 5){
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("GameOver",1);
            GameManager.Instance.GameOver();
        }

    }

    void OnMouseDown() {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        StartCoroutine(deactivateBubble());
    }

    IEnumerator deactivateBubble() {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }

}

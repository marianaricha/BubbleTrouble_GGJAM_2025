using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("HideTitle", 2f);
    }

    void HideTitle(){
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
    }
}

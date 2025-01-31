using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    public GameObject SocialBubble;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(1,0);
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float dy = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        if(dx < 0)
            direction.x = -1;
        else if(dx > 0)
            direction.x = 1;
        else if(dy < 0)
            direction.y = -1;
        else if(dy> 0)
            direction.y = 1;
    
        transform.Translate(dx, dy, 0);
    }

}

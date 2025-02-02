using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float speed;
    float time =0;
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
        time += Time.deltaTime;
        if(time > 1.5){
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
        
            //transform.Translate(dx, dy, 0);
            Vector3 newPosition = transform.position + new Vector3(dx, dy, 0);
            newPosition.x = Mathf.Clamp(newPosition.x, -13.8f, 13.8f);
            newPosition.y = Mathf.Clamp(newPosition.y, -7f, 7f);

            transform.position = newPosition;
        }
        
    }

}

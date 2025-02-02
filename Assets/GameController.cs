using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float speed;
    float time =0;
    public Vector2 direction;
    public GameObject SocialBubble;
    private Animator animator;
    public float maxX, minX, MaxY, MinY;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(1,0);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal");
        if(time > 1.5){
            float dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float dy = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            Vector3 newPosition = transform.position + new Vector3(dx, dy, 0);
            if(horizontalInput > 0.01f){
                transform.localScale = Vector3.one;
            }else if(horizontalInput < -0.01f){
                transform.localScale = new Vector3(-1, 1, 1);
            }

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY);

            transform.position = newPosition;
            animator.SetBool("Walking", horizontalInput != 0);
        }
        
    }

}

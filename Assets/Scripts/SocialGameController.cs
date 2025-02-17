/*using System.Collections;
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

}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialGameController : MonoBehaviour
{
    private float speed = 5f;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    private Vector3 target;
    
    private bool moving = false;

    void Start()
    {
        target = transform.position;
        speed = speed * GameManager.Instance.velocityBoost;
    }
    void Update()
    {   
        if(Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)){
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0f;
            moving = true;
        }
        if(target == transform.position){
            moving = false;
        }
        animator.SetBool("Walking", moving);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}

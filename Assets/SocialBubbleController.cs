using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialBubbleController : MonoBehaviour
{
    public GameController gameController;
    public GameObject circle;
    private float tempo = 0;
    public float raioMaximo;
    public float speed;
    public float tempoDeEspera;

    void Update()
    {
        tempo += Time.deltaTime;
        if (circle != null)
        {
            float distancia = Vector3.Distance(circle.transform.position, transform.position);
            
            if (distancia > raioMaximo)
            {
                Vector3 direcao = (circle.transform.position - transform.position).normalized;
                transform.position += direcao * Time.deltaTime *speed; // Movendo a bolha na direção do círculo
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SetParent(transform);
    }
}

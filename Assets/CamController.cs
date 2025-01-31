using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform personagem; // Arraste o personagem no Inspector
    public float minX, maxX, minY, maxY; // Limites da câmera

    void LateUpdate()
    {
        if (personagem != null)
        {
            float z = transform.position.z; // Mantém o Z fixo
            float x = Mathf.Clamp(personagem.position.x, minX, maxX); // Segue o X dentro dos limites
            float y = Mathf.Clamp(personagem.position.y, minY, maxY); // Segue o Y dentro dos limites

            transform.position = new Vector3(x, y, z); // Move a câmera
        }
    }
}

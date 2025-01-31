using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform personagem;
    public float minX, maxX, minY, maxY;
    void LateUpdate()
    {
        if (personagem != null)
        {
            float z = transform.position.z;
            float x = Mathf.Clamp(personagem.position.x, minX, maxX);
            float y = Mathf.Clamp(personagem.position.y, minY, maxY);

            transform.position = new Vector3(x, y, z);
        }
    }
}

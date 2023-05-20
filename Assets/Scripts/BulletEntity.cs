using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEntity : MonoBehaviour
{
    public float speed = 10.0f; // Kurþun hýzý

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Kurþunu hareket ettir
        Destroy(gameObject, 2f); // Kurþunun ömrünü belirle
    }

    
}

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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Eðer kurþun düþmana çarparsa
        {
            Destroy(other.gameObject); // Düþmaný yok et
            Destroy(gameObject); // Kurþunu yok et
        }
    }
}

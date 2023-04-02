using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEntity : MonoBehaviour
{
    public float speed = 10.0f; // Kur�un h�z�

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Kur�unu hareket ettir
        Destroy(gameObject, 2f); // Kur�unun �mr�n� belirle
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // E�er kur�un d��mana �arparsa
        {
            Destroy(other.gameObject); // D��man� yok et
            Destroy(gameObject); // Kur�unu yok et
        }
    }
}

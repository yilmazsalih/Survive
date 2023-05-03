using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab; // Kurþunun prefab'ý
    public Transform firePoint; // Kurþunun çýkacaðý nokta
    public float fireRate = 0.5f; // Atýþ hýzý
    private float nextFire = 0.0f; // Bir sonraki atýþ zamaný
    public bool canAttack = false;

    void FixedUpdate()
    {
        if (canAttack == false) return;
        if (Time.time > nextFire) // Bir sonraki atýþ zamaný geldiðinde
        {
            nextFire = Time.time + fireRate; // Bir sonraki atýþ zamanýný ayarla
            Shoot(); // Ateþ et
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Kurþunu oluþtur
    }
}

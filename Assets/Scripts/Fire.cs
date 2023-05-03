using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab; // Kur�unun prefab'�
    public Transform firePoint; // Kur�unun ��kaca�� nokta
    public float fireRate = 0.5f; // At�� h�z�
    private float nextFire = 0.0f; // Bir sonraki at�� zaman�
    public bool canAttack = false;

    void FixedUpdate()
    {
        if (canAttack == false) return;
        if (Time.time > nextFire) // Bir sonraki at�� zaman� geldi�inde
        {
            nextFire = Time.time + fireRate; // Bir sonraki at�� zaman�n� ayarla
            Shoot(); // Ate� et
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Kur�unu olu�tur
    }
}

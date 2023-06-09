using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    public GameObject explosionPrefab; // Par�ac�k efekti i�in haz�r bir prefab olu�turulmu�sa, buraya s�r�kleyip b�rakabilirsiniz.
    private Action onDead;
    
    public float moveSpeed = 5f;    // D��man�n hareket h�z�

    private Vector3 startPosition;  // D��man�n ba�lang�� pozisyonu
    private Vector3 targetPosition;  // D��man�n hedef pozisyonu

    // Ba�lang��ta �a�r�lan "Start" fonksiyonu
    void Start()
    {
        moveSpeed *= PlayerPrefs.GetInt("level", 1);
        // D��man�n ba�lang�� pozisyonunu kaydediyoruz
        startPosition = transform.position;

        // D��man�n hedef pozisyonunu hesapl�yoruz
        targetPosition = startPosition + new Vector3(0, 0, -30);
    }

    // Her �er�evede �a�r�lan "Update" fonksiyonu
    void Update()
    {
        // D��man�n hedefine do�ru hareket etmesi i�in "MoveTowards" fonksiyonunu kullan�yoruz
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    internal void SetDependencies(Action onEnemyDead)
    {
        onDead = onEnemyDead;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) // E�er kur�un d��mana �arparsa
        {
            
            onDead?.Invoke();
            Destroy(other.gameObject); // D��man� yok et
            Destroy(gameObject); // Kur�unu yok et
        }
    }
    public void OnDisable()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
    
}

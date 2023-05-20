using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    public GameObject explosionPrefab; // Parçacýk efekti için hazýr bir prefab oluþturulmuþsa, buraya sürükleyip býrakabilirsiniz.
    private Action onDead;
    
    public float moveSpeed = 5f;    // Düþmanýn hareket hýzý

    private Vector3 startPosition;  // Düþmanýn baþlangýç pozisyonu
    private Vector3 targetPosition;  // Düþmanýn hedef pozisyonu

    // Baþlangýçta çaðrýlan "Start" fonksiyonu
    void Start()
    {
        moveSpeed *= PlayerPrefs.GetInt("level", 1);
        // Düþmanýn baþlangýç pozisyonunu kaydediyoruz
        startPosition = transform.position;

        // Düþmanýn hedef pozisyonunu hesaplýyoruz
        targetPosition = startPosition + new Vector3(0, 0, -30);
    }

    // Her çerçevede çaðrýlan "Update" fonksiyonu
    void Update()
    {
        // Düþmanýn hedefine doðru hareket etmesi için "MoveTowards" fonksiyonunu kullanýyoruz
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    internal void SetDependencies(Action onEnemyDead)
    {
        onDead = onEnemyDead;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) // Eðer kurþun düþmana çarparsa
        {
            
            onDead?.Invoke();
            Destroy(other.gameObject); // Düþmaný yok et
            Destroy(gameObject); // Kurþunu yok et
        }
    }
    public void OnDisable()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
    
}

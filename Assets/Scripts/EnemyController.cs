using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;        // Olu�turulacak d��man�n �nceden haz�rlanm�� prefab'�
    public float spawnInterval = 3f;      // D��manlar�n olu�turulma aral���
    public Transform spawnStartPoint;     // D��manlar�n olu�turulmaya ba�layaca�� pozisyon
    public Transform spawnEndPoint;       // D��manlar�n olu�turulma noktas�
    private float spawnTimer = 0f;        // Olu�turma zamanlay�c�s�
    
    // Her �er�evede �a�r�lan "Update" fonksiyonu
    void Update()
    {
        // Belirli aral�klarla d��man olu�turmak i�in bir zamanlay�c� kullan�yoruz
        spawnTimer += Time.deltaTime;

        // E�er zamanlay�c� belirtilen aral��a ula�t�ysa yeni bir d��man olu�turuyoruz
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;  // Zamanlay�c�y� s�f�rl�yoruz
        }
    }

    // Yeni bir d��man olu�turmak i�in �a�r�lan fonksiyon
    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        var Enemy= Instantiate(enemyPrefab, transform);
        Enemy.transform.position = spawnPosition;
        Enemy.transform.localEulerAngles = Vector3.zero;
    }

    // Belirli iki nokta aras�nda rastgele bir nokta d�nd�ren fonksiyon
    Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(spawnStartPoint.position.x, spawnEndPoint.position.x);
        float randomZ = Random.Range(spawnStartPoint.position.z, spawnEndPoint.position.z);
        return new Vector3(randomX, spawnStartPoint.position.y, randomZ);
    }
}
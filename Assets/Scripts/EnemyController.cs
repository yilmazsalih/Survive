using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyEntity enemyPrefab;        // Oluþturulacak düþmanýn önceden hazýrlanmýþ prefab'ý
    public float spawnInterval = 3f;      // Düþmanlarýn oluþturulma aralýðý
    public Transform spawnStartPoint;     // Düþmanlarýn oluþturulmaya baþlayacaðý pozisyon
    public Transform spawnEndPoint;       // Düþmanlarýn oluþturulma noktasý
    private float spawnTimer = 0f;        // Oluþturma zamanlayýcýsý
    public bool canSpawn = false;
    public int initEnemyCount;
    public GameObject success;
    private int enemyCount;
    // Her çerçevede çaðrýlan "Update" fonksiyonu
    private void Awake()
    {
        enemyCount =initEnemyCount* PlayerPrefs.GetInt("level", 1);
    }
    void Update()
    {
        
        if (canSpawn == false) return;
        // Belirli aralýklarla düþman oluþturmak için bir zamanlayýcý kullanýyoruz
        spawnTimer += Time.deltaTime;

        // Eðer zamanlayýcý belirtilen aralýða ulaþtýysa yeni bir düþman oluþturuyoruz
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;  // Zamanlayýcýyý sýfýrlýyoruz
        }
    }
    public void OnEnemyDead()
    {
        enemyCount--;
        if(enemyCount <= 0)
        {
            canSpawn = false;
            success.SetActive(true);
        }
    }

    // Yeni bir düþman oluþturmak için çaðrýlan fonksiyon
    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        var Enemy= Instantiate(enemyPrefab, transform);
        Enemy.transform.position = spawnPosition;
        Enemy.transform.localEulerAngles = Vector3.zero;
        Enemy.SetDependencies(OnEnemyDead);
        
    }

    // Belirli iki nokta arasýnda rastgele bir nokta döndüren fonksiyon
    Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(spawnStartPoint.position.x, spawnEndPoint.position.x);
        float randomZ = Random.Range(spawnStartPoint.position.z, spawnEndPoint.position.z);
        return new Vector3(randomX, spawnStartPoint.position.y, randomZ);
    }
}

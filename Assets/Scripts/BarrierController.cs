using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarrierController : MonoBehaviour
{
    public float startingHealth = 50; // bariyerin baþlangýçtaki can miktarý
    public float currentHealth; // bariyerin mevcut can miktarý
    public Image image;
    public GameObject failScreen;

    void Start()
    {
        currentHealth = startingHealth;
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            currentHealth -= 1; // bariyerin hasarý absorbe etmesi
            image.fillAmount = currentHealth / startingHealth;
            if (currentHealth <= 0) // bariyerin caný sýfýr olduðunda bariyeri yok eder
            {
                failScreen.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}

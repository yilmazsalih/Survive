using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarrierController : MonoBehaviour
{
    public int startingHealth = 50; // bariyerin baþlangýçtaki can miktarý
    public int currentHealth; // bariyerin mevcut can miktarý
    public TMP_Text healthText; // can miktarýnýn görüntüleneceði UI elemaný

    void Start()
    {
        currentHealth = startingHealth;
        healthText.text = currentHealth.ToString();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            currentHealth -= 1; // bariyerin hasarý absorbe etmesi
            healthText.text = currentHealth.ToString();
            if (currentHealth <= 0) // bariyerin caný sýfýr olduðunda bariyeri yok eder
            {
                Destroy(gameObject);
            }
        }
    }
}

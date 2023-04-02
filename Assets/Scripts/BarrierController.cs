using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarrierController : MonoBehaviour
{
    public int startingHealth = 50; // bariyerin ba�lang��taki can miktar�
    public int currentHealth; // bariyerin mevcut can miktar�
    public TMP_Text healthText; // can miktar�n�n g�r�nt�lenece�i UI eleman�

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
            currentHealth -= 1; // bariyerin hasar� absorbe etmesi
            healthText.text = currentHealth.ToString();
            if (currentHealth <= 0) // bariyerin can� s�f�r oldu�unda bariyeri yok eder
            {
                Destroy(gameObject);
            }
        }
    }
}

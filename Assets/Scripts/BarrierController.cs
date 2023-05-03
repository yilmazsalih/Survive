using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarrierController : MonoBehaviour
{
    public float startingHealth = 50; // bariyerin ba�lang��taki can miktar�
    public float currentHealth; // bariyerin mevcut can miktar�
    public Image image;

    void Start()
    {
        currentHealth = startingHealth;
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            currentHealth -= 1; // bariyerin hasar� absorbe etmesi
            image.fillAmount = currentHealth / startingHealth;
            if (currentHealth <= 0) // bariyerin can� s�f�r oldu�unda bariyeri yok eder
            {
                Destroy(gameObject);
            }
        }
    }
}

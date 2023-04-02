using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin hareket h�z�
    private float leftLimit = -3f; // Hareketin sol s�n�r�
    private float rightLimit = 3f; // Hareketin sa� s�n�r�

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) // Parmak hareket etti�inde
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition; // Parmak pozisyonunu al

            Vector3 newPosition = transform.position + new Vector3(touchDeltaPosition.x * moveSpeed * Time.deltaTime, 0f, 0f); // Yeni pozisyonu hesapla
            newPosition.x = Mathf.Clamp(newPosition.x, leftLimit, rightLimit); // Yeni pozisyonu s�n�rland�r
            transform.position = newPosition; // Karakteri yeni pozisyona ta��
        }
    }
}

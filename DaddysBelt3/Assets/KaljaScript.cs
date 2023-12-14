using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaljaScript : MonoBehaviour
{
    public int kaljatmaara = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Varmista, että kyseessä on pelaaja, vaihda tagin nimi tarvittaessa
        {
            kaljatmaara++;         
            Destroy(gameObject);
        }
    }
}

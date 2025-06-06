using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Controlla se l'oggetto che ha attivato il trigger è il giocatore
        {
            PlayerController player = collision.GetComponent<PlayerController>(); // Ottieni il componente PlayerController dal giocatore
            if (player != null)
            {
                player.PickUpItem(gameObject); // Chiama il metodo PickUpItem del giocatore, passando questo oggetto come argomento
                Destroy(gameObject); // Distruggi l'oggetto PickUp dopo che è stato raccolto
            }
        }
    }

}

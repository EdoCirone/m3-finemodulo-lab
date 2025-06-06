using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    AbstractWeapon weapon; // Riferimento all'arma che il giocatore pu� raccogliere

    void Start()
    {
        weapon = GetComponent<AbstractWeapon>(); // Ottieni il componente AbstractWeapon dall'oggetto PickUp
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Controlla se l'oggetto che ha attivato il trigger � il giocatore
        {
            PlayerController player = collision.GetComponent<PlayerController>(); // Ottieni il componente PlayerController dal giocatore
            if (player != null)
            {
                player.PickUpItem(gameObject); // Chiama il metodo PickUpItem del giocatore, passando questo oggetto come argomento
                weapon.Equip();
                Destroy(gameObject); // Distruggi l'oggetto PickUp dopo che � stato raccolto
            }
        }
    }

}

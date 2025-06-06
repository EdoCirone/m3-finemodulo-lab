using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerController _player;

    private void Awake()
    {

        _player = FindAnyObjectByType<PlayerController>();

    }

    private void FixedUpdate()
    {
        EnemyMovement(); // Muovo il nemico verso il giocatore
    }

    public void EnemyMovement()
    {
        if (_player != null)
        {

            // Calcola la direzione verso il giocatore
            Vector2 direction = (_player.transform.position - transform.position).normalized;

            // Muovo il nemico nella direzione del giocatore, ho trovato MoveTowards che mi permette di muovere un oggetto verso un altro oggetto con una velocità specifica
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, 2f * Time.deltaTime);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _player.gameObject)
        {

            Destroy(gameObject); // Distrugge il nemico quando colpisce il giocatore

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerController _player;
    TopDownMover _mover;
    Vector2 _direction;

    private void Awake()
    {

        _player = FindAnyObjectByType<PlayerController>();
        _mover = GetComponent<TopDownMover>();

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
            _direction = (_player.transform.position - transform.position).normalized;

            _movement.SetSpeed(_moveSpeed);
            _movement.SetDirection(direction);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerController _player;
    TopDownMovement _mover;
    LifeController _lifeController;

    Vector2 _direction;

    private void Awake()
    {
        _lifeController = GetComponent<LifeController>();
        _player = FindAnyObjectByType<PlayerController>();
        _mover = GetComponent<TopDownMovement>();

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

            _mover.SetDirection(_direction);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _player.gameObject)
        {

            _lifeController.RemoveHp(_lifeController.CurrentHp);

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    [SerializeField] float _lifeTime = 5; // Durata del proiettile in secondi
    [SerializeField] float _speed = 10f; // Velocità del proiettile

    [SerializeField] int _damage = 10; // Danno del proiettile

    Vector2 _direction; // Direzione del proiettile

    Rigidbody2D _rb; // Riferimento al componente Rigidbody2D del proiettile

    void Awake()
    {
        // Prendo il componente Rigidbody2D per gestire la fisica del proiettile
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_lifeTime > 0)
        {
            _lifeTime -= Time.deltaTime;
            if (_lifeTime <= 0)
            {
                Destroy(gameObject); // Distrugge il proiettile se il tempo di vita è scaduto
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Distruggo il proiettile quando collide con un oggetto
        Destroy(gameObject);
    }
}



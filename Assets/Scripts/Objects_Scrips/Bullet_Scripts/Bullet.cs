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
        if (collision.gameObject.GetComponent<LifeController>()) // Controlla se il proiettile ha colpito un nemico
        {
            LifeController lifeController = collision.gameObject.GetComponent<LifeController>();
            lifeController.RemoveHp(_damage); // Rimuove i punti vita al nemico
        }

        // Distruggo il proiettile quando collide con un oggetto
        Destroy(gameObject);
    }

    public void Shoot(Vector3 position,Vector3 direction)
    {

        Vector2 dir = direction;

        float squaredLenght = dir.sqrMagnitude;

        if (squaredLenght > 1)
        {
            dir /= Mathf.Sqrt(squaredLenght);// Normalizza la direzione
        }

        _rb.velocity = dir * _speed; // Imposta la velocità del proiettile
        if (dir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }

    }
}



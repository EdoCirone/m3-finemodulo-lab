using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : AbstractWeapon
{

    [SerializeField] private float _range = 10f; // Range dell'arma, impostato a 10 unità


    Enemy[] enemies; // Array per memorizzare i nemici nella scena

    // Update is called once per frame
    void Update()
    {
        enemies = FindObjectsOfType<Enemy>(); // Trova tutti gli oggetti di tipo Enemy nella scena

        foreach (Enemy enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= _range) // Controlla se il nemico è entro il range
            {
                Vector3 direction = (enemy.transform.position - transform.position).normalized; // Calcola la direzione verso il nemico

                if (CanShoot()) // Controlla se l'arma può sparare
                {
                    TryShoot( transform.position, direction); // Prova a sparare nella direzione del nemico
                }
            }
        }
    }
}

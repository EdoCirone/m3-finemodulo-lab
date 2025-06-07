using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : AbstractWeapon
{

    [SerializeField] private float _range = 10f; // Range dell'arma, impostato a 10 unità


    Enemy[] enemies; // Array per memorizzare i nemici nella scena
    Enemy _nearest;

    // Update is called once per frame
    void Update()
    {
        if (!CanShoot()) return;

        _nearest = FindNearestEnemy();

        if (_nearest != null ) // Controlla che esista un nemico da colpire

        {

            Vector3 direction = (_nearest.transform.position - transform.position).normalized;//definisce la direzione del nemico più vicino
            TryShoot(transform.position, direction); // Prova a sparare nella direzione del nemico

        }

    }

    Enemy FindNearestEnemy() //Cerco il nemico più vicino
    {
        enemies = FindObjectsOfType<Enemy>(); //Inserisco i nemici della scena in un array
        Enemy nearest = null; 
        float minDistance = _range;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position); //salvo la distanza del nemico

            if (distance <= minDistance) //Controllo la distanza con la distanza minima accettabile
            {
                minDistance = distance; //Rendo la distanza del nemico preso in esame la nuova distanza minima

                nearest = enemy; //Rendo il nemico scelto il più vicino

            }

        }

        return nearest;
    }
}

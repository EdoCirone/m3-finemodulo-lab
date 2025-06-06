using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int _numersOfEnemies = 5; // Numero di nemici da generare
    [SerializeField] float _spawnRadius = 10f; // Raggio entro il quale generare i nemici

    [SerializeField] GameObject enemyObject; // Oggetto prefab del nemico da generare

   List<GameObject> enemies = new List<GameObject>(); // Lista per tenere traccia dei nemici generati

    void Start()
    {

        SpawnEnemy();

    }

    void Update()
    {
        enemies.RemoveAll(enemy => enemy == null); // Rimuove i nemici che sono stati distrutti o non esistono più

        if (enemies.Count == 0) // Se il numero di nemici nella scena è inferiore al numero desiderato, genero nuovi nemici
        {
            SpawnEnemy();
        }

    }

    void SpawnEnemy()
    {
        if (enemyObject != null)
        {
            for (int i = 0; i < _numersOfEnemies; i++)
            {
                // Crea un nuovo nemico e lo posiziona in una posizione casuale all'interno di un raggio

                Vector3 spawnPosition = new Vector3(Random.Range(-_spawnRadius, _spawnRadius), 0, Random.Range(-_spawnRadius, _spawnRadius));

                GameObject newEnemy = Instantiate(enemyObject, spawnPosition, Quaternion.identity);

                enemies.Add(newEnemy); // Aggiungo il nuovo nemico alla lista dei nemici


                newEnemy.name = "Enemy_" + i; // Assegna un nome univoco al nemico
            }
        }

    }
}

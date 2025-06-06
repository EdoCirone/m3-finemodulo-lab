using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{

    [SerializeField] private int _maxHp = 100; // Punti vita massimi
    [SerializeField] private int _currentHp; // Punti vita attuali

    //public int GetHp() => _currentHp; // Restituisce i punti vita attuali
    //public int GetMaxHp() => _maxHp; // Restituisce i punti vita massimi

    //Provo a usare le proprietà per accedere ai punti vita invece che i metodi
    public int CurrentHp => _currentHp;
    public int MaxHp => _maxHp;


    void Start()
    {
        _currentHp = _maxHp; // Inizializza i punti vita attuali al massimo
    }

    void CheckDeath()
    {
        if (_currentHp <= 0)
        {
            Debug.Log("Il personaggio è morto");
            Destroy(gameObject); // Distrugge l'oggetto se i punti vita sono zero o meno
        }
    }

    void SetHp(int hp)
    {
        _currentHp = Mathf.Clamp(hp, 0, _maxHp); // Assicura che i punti vita attuali non superino i massimi
        CheckDeath(); // Controlla se il personaggio è morto dopo aver impostato i punti vita
    }

    public void AddHp(int amount) => SetHp(_currentHp + amount); //Aggiunge punti vita

    public void RemoveHp(int amount) => SetHp(_currentHp - amount);//Rimuove punti vita

}

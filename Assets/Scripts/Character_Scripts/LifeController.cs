using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeController : MonoBehaviour
{

    [SerializeField] private int _maxHp = 100; // Punti vita massimi
    [SerializeField] private int _currentHp; // Punti vita attuali

    //Creo un timer perchè altrimenti non vedo l'effetto di cambio colore
    [SerializeField] private float _advisorTime = 0.2f;
    float _timer = 0;

    SpriteRenderer _renderer;

    //public int GetHp() => _currentHp; // Restituisce i punti vita attuali
    //public int GetMaxHp() => _maxHp; // Restituisce i punti vita massimi

    //Provo a usare le proprietà per accedere ai punti vita invece che i metodi
    public int CurrentHp => _currentHp;
    public int MaxHp => _maxHp;

    public bool IsAlive { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        _currentHp = _maxHp; // Inizializza i punti vita attuali al massimo
        IsAlive = true;
    }

    void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else if (_renderer.color != Color.white)
        {
            _renderer.color = Color.white;
        }


    }

    void CheckDeath()
    {
        if (_currentHp <= 0)
        {
            if (tag == "Player")
            {
                Debug.Log("Hanno vinto i polli, forse il pollo sei tu");
            }
            else
            {
                Debug.Log($"Il personaggio {name} è morto");
            }

            IsAlive = false;
            Destroy(gameObject); // Distrugge l'oggetto se i punti vita sono zero o meno
        }
    }

    void SetHp(int hp)
    {
        _currentHp = Mathf.Clamp(hp, 0, _maxHp); // Assicura che i punti vita attuali non superino i massimi
        CheckDeath(); // Controlla se il personaggio è morto dopo aver impostato i punti vita
    }

    public void AddHp(int amount) => SetHp(_currentHp + amount); //Aggiunge punti vita

    public void RemoveHp(int amount)
    {
        _renderer.color = Color.red;
        _timer = _advisorTime;
        SetHp(_currentHp - amount);

    }//Rimuove punti vita

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _fireRate = 0.5f; // Intervallo tra i colpi
    public bool isEquiped { get; set; } = false; // Indica se l'arma è equipaggiata o meno

    private float _lastShotTimer = 0f; // Tempo trascorso dall'ultimo colpo

    public bool CanShoot()
    {
        return Time.time - _lastShotTimer >= _fireRate;
    }

    public virtual void Equip()

    {
        isEquiped = true;
        _lastShotTimer = Time.time; // Reset del timer dell'ultimo colpo quando l'arma viene equipaggiata
    }

    public virtual void UnEquip()

    {
        isEquiped = false;
    }

    public void TryShoot( Vector3 position ,Vector3 direction)
    {
        if (!isEquiped || !CanShoot()) return;

        Shoot( position, direction);

    }

    public void Shoot(Vector3 position, Vector3 direction)
    {
        _lastShotTimer = Time.time; // Aggiorna il timer dell'ultimo colpo
        Bullet b = Instantiate(_bulletPrefab, position, Quaternion.identity);
        b.Shoot( position, direction);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private float _horizontalInput;
    private float _verticalInput;

    [SerializeField] private Transform _weaponSlot;
    public Vector2 MovementInput { get; private set; }

    Rigidbody2D _rb;
    [SerializeField] private AbstractWeapon _equipedWeapon; // Reference to the weapon prefab


    private void Start()
    {
        // Prendo il rigibody2D del player
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        // Prendo gli input orizzontali e verticali del player
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        // Normalizzo gli input per evitare che la velocità sia maggiore quando si muove in diagonale

        MovementInput = new Vector2(_horizontalInput, _verticalInput).normalized;


    }

    private void FixedUpdate()
    {
        //Muovo il player con MovePosition.

        _rb.MovePosition(_rb.position + MovementInput * _speed * Time.fixedDeltaTime);
    }

    public void PickUpItem(GameObject item)
    {
        AbstractWeapon originalWeapon = item.GetComponent<AbstractWeapon>();

        if (originalWeapon != null)
        {
           

            GameObject cloneItem = Instantiate(item, _weaponSlot.position, Quaternion.identity, transform);

            AbstractWeapon cloneWeapon = cloneItem.GetComponent<AbstractWeapon>();

            if (cloneWeapon != null)
            {
               

                // Se ho già un'arma equipaggiata, la dis-equipaggio
                if (_equipedWeapon != null)
                {
                    _equipedWeapon.UnEquip();
                }
                // Equipaggio la nuova arma
                _equipedWeapon = cloneWeapon;
                _equipedWeapon.Equip();
            }

            else
            {
                Debug.Log("Questo oggetto non è un arma");
            }

            Debug.Log("Item Preso");

          
        }

    }
}

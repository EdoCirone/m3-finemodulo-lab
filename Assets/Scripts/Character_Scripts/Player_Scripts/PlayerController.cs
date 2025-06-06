using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;

    [SerializeField] private Transform _weaponSlot;
    public Vector2 MovementInput { get; private set; }

    TopDownMovement _mover;
    Rigidbody2D _rb;
    [SerializeField] private AbstractWeapon _equipedWeapon; // Reference to the weapon prefab

    private void Start()
    {
        // Prendo il rigibody2D del player
        _rb = GetComponent<Rigidbody2D>();
        _mover = GetComponent<TopDownMovement>();
    }
    private void Update()
    {

        // Prendo gli input orizzontali e verticali del player
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        // Normalizzo gli input per evitare che la velocità sia maggiore quando si muove in diagonale

        MovementInput = new Vector2(_horizontalInput, _verticalInput);
        _mover.SetDirection(MovementInput);


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

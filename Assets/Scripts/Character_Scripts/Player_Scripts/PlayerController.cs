using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private float _horizontalInput;
    private float _verticalInput;

    public Vector2 MovementInput { get; private set; }
    Rigidbody2D _rb;


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
}

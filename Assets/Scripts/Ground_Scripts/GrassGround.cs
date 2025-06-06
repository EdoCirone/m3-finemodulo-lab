using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGround : MonoBehaviour
{
    [SerializeField] private float _debuff = 0.5f; // Dimezza la velocità del player quando è su questo terreno


    private void OnTriggerEnter2D(Collider2D collision)
    {

        TopDownMovement _mover = collision.GetComponent<TopDownMovement>(); // Prendo il componente TopDownMovement del player che entra nel trigger

        if (_mover != null)
        {
            _mover.SpeedDebuff(_debuff); // Dimezza la velocità del player quando è su questo terreno
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        TopDownMovement _mover = collision.GetComponent<TopDownMovement>();

        if (_mover != null)
        {
            _mover.SpeedDebuff(1 / _debuff); // Ripristina la velocità del player quando esce dal terreno
        }

    }



}

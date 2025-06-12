using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sto raggionando su fare una classe SpeedModifierGround che gestisca tutte le modifiche sulla speed.
public class GrassGround : MonoBehaviour
{
    [SerializeField] private float _debuff = 0.5f; 


    private void OnTriggerEnter2D(Collider2D collision)
    {

        TopDownMovement _mover = collision.GetComponent<TopDownMovement>(); // Prendo il componente TopDownMovement del player che entra nel trigger

        if (_mover != null && !_mover.IsSpeedBoosted())
        {
            _mover.SpeedDebuff(_debuff); // Applico il debuff
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        TopDownMovement _mover = collision.GetComponent<TopDownMovement>();

        if (_mover != null)
        {
            _mover.ResetSpeed(); // Ripristina la velocità del player quando esce dal terreno
        }

    }



}

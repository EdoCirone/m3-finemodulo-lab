using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    PlayerController _playerController;
    Animator _animator;

    private void Awake()
    {
        //Prendo i componenti necessari all'animazione del giocatore

        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Chiamo la funzione che controlla l'animazione del giocatore
        AnimationUpdate();
    }

    void AnimationUpdate()
    {


        // Controlla se il giocatore si sta muovendo
        if (_playerController.MovementInput != Vector2.zero)
        {
            // Esegui l'animazione di movimento
            Debug.Log("mi sto muovendo");
            _animator.SetBool("IsMoving", true);
            _animator.SetFloat("horizontal", _playerController.MovementInput.x);
            _animator.SetFloat("vertical", _playerController.MovementInput.y);
        }
        else
        {
            Debug.Log("StoFermo");
            // Esegui l'animazione di idle
            _animator.SetBool("IsMoving", false);
        }

    }

}

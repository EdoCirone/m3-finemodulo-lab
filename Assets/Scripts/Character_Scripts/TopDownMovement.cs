using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    float originalSpeed;
    public bool HasDirection() => _dir != Vector2.zero;

    bool isBoosted = false;

    [SerializeField] float speed = 2;

    Vector2 _dir;

   

    public float GetSpeed() { return speed; }


    public void SetSpeed(float speed)
    {

        this.speed = speed;
        isBoosted = true;

    }

    public void SpeedDebuff (float debuff)
    {
        speed *= debuff;
        isBoosted = true;
    }


    public void ResetSpeed()
    {
        speed = originalSpeed;
        isBoosted = false;
    }
    public bool IsBoosted() => isBoosted;

    public void SetDirection(Vector2 dir)
    {
        float sqrLenght = dir.sqrMagnitude;
        if (sqrLenght > 1)
        {
            dir = dir / Mathf.Sqrt(sqrLenght);
        }

        _dir = dir;
    }

    // Start is called before the first frame update
    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
        originalSpeed = speed;

    }



    void FixedUpdate()
    {
        if (_dir != Vector2.zero)
        {

            _rb.MovePosition(_rb.position + _dir * (speed * Time.fixedDeltaTime));

        }


    }

}

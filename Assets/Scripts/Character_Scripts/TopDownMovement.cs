using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    float originalSpeed;
    public bool HasDirection() => _dir != Vector2.zero;

    bool isSpeedBoosted = false;

    [SerializeField] float speed = 2;

    Vector2 _dir;



    public float GetSpeed() { return speed; }


    public void SetSpeed(float speed)
    {

        this.speed = speed;
        isSpeedBoosted = true;

    }

    public void SpeedDebuff(float debuff)
    {
        speed *= debuff;
        isSpeedBoosted = true;
    }


    public void ResetSpeed()
    {
        if (isSpeedBoosted)
        {
            speed = originalSpeed;
            isSpeedBoosted = false;
        }
    }
    public bool IsSpeedBoosted() => isSpeedBoosted;

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

    private void Awake()
    {

        _rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {

        originalSpeed = speed;

    }



    void FixedUpdate()
    {
        if (_dir != Vector2.zero)
        {

            _rb.MovePosition(_rb.position + _dir * (speed * Time.fixedDeltaTime));

            //Giro il character nella direzione in cui si sposta

            //if (_dir.x > 0)
            //{
            //    transform.localScale = new Vector3(-1, 1, 1);
            //}
            //else
            //{
            //    transform.localScale = Vector3.one;
            //}
        }


    }

}

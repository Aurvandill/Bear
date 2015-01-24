using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Creature
{
    [SerializeField]
    private Slider _slider;


    Animator _animator;
    float _speed = 1f;

    public override void Start()
    {
        base.Start();

        _animator = GetComponent<Animator>();
    }

    public void Update()
    {
        Attack();
    }

    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _speed = Input.GetAxis("Charge") + 1f;

        float moveH = Input.GetAxis("Horizontal") * _moveSpeed * _speed;
        float moveV = Input.GetAxis("Vertical") * _moveSpeed * _speed;

        var direction = (moveH == 0) ? 0 : ((moveH > 0) ? 1 : -1);


        transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(moveH, moveV);

        if (direction != 0)
        {
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }


        if (_animator != null)
        {
            _animator.SetFloat("Speed", Mathf.Abs(moveH) * 10 + Mathf.Abs(moveV) * 10);
        }

        _animator.SetBool("Run", _speed > 1f);
    }

    private void Attack()
    {
        if (Input.GetAxisRaw("Attack") == 1)
        {
            _currentWeapon.Attack();
        }
    }

    protected override void OnHealthChanged(float health)
    {
        if (_slider != null)
        {
            _slider.value = health;
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Entity
{
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
        float moveH = Input.GetAxis("Horizontal") * _moveSpeed;
        float moveV = Input.GetAxis("Vertical") * _moveSpeed;

        var direction = (moveH == 0) ? 0 : ((moveH > 0) ? 1 : -1);

        transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(moveH, moveV);

        if (direction != 0)
        {
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }
    }

    private void Attack()
    {
        if (Input.GetAxisRaw("Attack") == 1)
        {
            _currentWeapon.Attack();
        }
    }
}

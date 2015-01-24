using UnityEngine;
using System.Collections;

public class Melee : Enemy
{
    void FixedUpdate()
    {
        Vector3 targetPos = transform.position;

        if (CurrentTarget != null)
        {
            targetPos = CurrentTarget.gameObject.transform.position;
        }
        else if ((transform.position - ReturnPosition).magnitude > 0.1)
        {
            targetPos = ReturnPosition;
        }



        var direction = (targetPos - transform.position).normalized;

        rigidbody2D.velocity = direction * _moveSpeed;
    }
}

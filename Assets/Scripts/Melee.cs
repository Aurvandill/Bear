using UnityEngine;
using System.Collections;

public class Melee : Enemy
{
    private bool stopped = false;
    private Animator _animator;

    public override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PrepareAttack();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!_currentWeapon.IsTargetInRange() && !stopped)
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
            transform.position = transform.position + direction * _moveSpeed;

            var direction1D = (direction.x == 0) ? 0 : ((direction.x > 0) ? 1 : -1);

            if (direction1D != 0)
            {
                transform.localScale = new Vector3(direction1D, transform.localScale.y, transform.localScale.z);
            }

            _animator.SetFloat("Speed", direction.magnitude);
        }
    }

    private void PrepareAttack()
    {
        if (_currentWeapon.RequestIsReady())
        {
            _animator.SetTrigger("Attack");
            stopped = true;
        }
    }

    private void ExecuteAttack()
    {
        if (_currentWeapon.IsTargetInRange())
        {
            _currentWeapon.Attack();          
        }

        stopped = false;
    }
}

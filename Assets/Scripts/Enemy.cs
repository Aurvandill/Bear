using UnityEngine;
using System.Collections;

public abstract class Enemy : Entity
{
    protected Entity CurrentTarget { get; private set; }
    protected Vector3 ReturnPosition { get; private set; }

    [SerializeField]
    protected GameObject _aggressionRange;
    [SerializeField]
    protected GameObject _disengageRange;


    public override void Start()
    {
        base.Start();
        ReturnPosition = transform.position;
    }

    public void OnEntityCollisionEnter(EntityCollisionEventArgs args)
    {
        if (args.SenderId.Equals(_aggressionRange.name))
        {
            var player = args.Entity as Player;
            if (player != null)
            {
                CurrentTarget = player;
            }
        }
    }

    public void OnEntityCollisionExit(EntityCollisionEventArgs args)
    {
        if (args.SenderId.Equals(_disengageRange.name))
        {
            CurrentTarget = null;
        }
    }
}

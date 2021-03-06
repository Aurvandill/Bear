﻿using UnityEngine;
using System.Collections;

public abstract class Enemy : Creature
{
    protected Creature CurrentTarget { get; set; }
    protected Vector3 ReturnPosition { get; private set; }
    [SerializeField]
    private GameObject Loot;

    [SerializeField]
    protected GameObject _aggressionRange;
    [SerializeField]
    protected GameObject _disengageRange;


    public override void Start()
    {
        base.Start();
        ReturnPosition = transform.position;
    }

    public virtual void OnEntityCollisionEnter(EntityCollisionEventArgs args)
    {
        var player = args.Entity as Player;
        if (player == null)
        {
            return;
        }

        if (args.SenderId.Equals(_aggressionRange.name))
        {
            CurrentTarget = player;
        }
    }

    public virtual void OnEntityCollisionExit(EntityCollisionEventArgs args)
    {
        var player = args.Entity as Player;
        if (player == null)
        {
            return;
        }

        if (args.SenderId.Equals(_disengageRange.name))
        {
            CurrentTarget = null;
        }
    }

    protected override void OnEntityDied()
    {
        if (Loot != null) {
            Instantiate(Loot, transform.position, Quaternion.identity);
        }

        base.OnEntityDied();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SardineFish.Unity.FSM;
using UnityEngine;

public class EntityStateMachine<TEntity> : EntityBehaviour<TEntity>, IFSM<EntityState<TEntity>> where TEntity:GameEntity
{
    [SerializeField]
    private EntityState<TEntity> state;
    public EntityState<TEntity> State => this.state;


    public bool ChangeState(EntityState<TEntity> nextState)
    {
        if (State != null && !State.OnExit(Entity, nextState, this))
            return false;
        if (!nextState.OnEnter(Entity, State, this))
            return false;
        state = nextState;
        return true;
    }

    void Update()
    {
        if (State)
            State.OnUpdate(Entity, this);
    }
}

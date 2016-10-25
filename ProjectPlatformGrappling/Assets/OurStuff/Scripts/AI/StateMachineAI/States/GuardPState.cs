﻿using UnityEngine;
using System.Collections;

public class GuardPState : PatrolState { //patrol fast letar efter spelaren
    public override void Execute(AIEntity entity)
    {
        if (_AIMoveable.currPatrolPoint == Vector3.zero || HasReached(_AIMoveable.transform.position, _AIMoveable.currPatrolPoint, 5, false))
        {
            _AIMoveable.currPatrolPoint = _AIMoveable.GetPatrolPoint();
        }
        _AIMoveable.Move(_AIMoveable.currPatrolPoint, _AIMoveable.currMovementSpeed);

        if(_AIMoveable.CheckForTarget(ref _AIMoveable.target))
        {
            Exit(entity);
        }
    }

    public override void Exit(AIEntity entity)
    {

        entity.StateEnded(GuardPState.Instance);
    }

    // singleton
    private static GuardPState instance; //finns över alla GuardPStates

    private static GuardPState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GuardPState();
            }

            return instance;
        }
    }

}

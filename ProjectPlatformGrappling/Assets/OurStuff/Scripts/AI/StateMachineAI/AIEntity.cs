﻿using UnityEngine;
using System.Collections;

public class AIEntity : BaseClass
{   //denna hanterar statesen, här får man använda derived sådana för att bestämma vilket state man vill köra
    [HideInInspector]
    public StatePatternAI statePattern;

    //alla statesen denna vill ha här:

    //alla statesen denna vill ha här:

    public override void Init()
    {
        base.Init();
        statePattern = new StatePatternAI(this);
    }
    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        //statePattern.ChangeState()
        statePattern.UpdateLoop();
	}

    public virtual void StateEnded(AIState endedState)
    {

    }

    public virtual void MakeDecision()
    {

    }

}

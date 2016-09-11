﻿using UnityEngine;
using System.Collections;

public class Trigger : BaseClass {
    [HideInInspector]
    public bool isTriggered = false;
    public float collisionExtent = 5;
    public LayerMask collisionMask;

    public ParticleSystem psActivated;
	// Use this for initialization
	void Start () {
        Init();
	}

    public override void Init()
    {
        base.Init();
        ToggleTrigger(false);
        //psActivated = this.transform.GetComponent<ParticleSystem>();
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    ToggleTrigger(true);
    //}

    //void OnTriggerExit(Collider col)
    //{
    //    //kolla ifall det står någon kvar
    //    ToggleTrigger(false);
    //}

    //void OnCollisionEnter(Collision col)
    //{
    //    ToggleTrigger(true);
    //}

    //void OnCollisionExit(Collision col)
    //{
    //    ToggleTrigger(false);
    //}

    public bool GetTriggered()
    {
        Collider[] col = Physics.OverlapBox(transform.position, new Vector3(collisionExtent, collisionExtent, collisionExtent), Quaternion.identity, collisionMask);
        if(col.Length > 0)
        {
            return true;
        }
        return false;
    }

    public void ToggleTrigger(bool b)
    {
        if(b)
        {
            psActivated.Simulate(0.0f, true, true);
            ParticleSystem.EmissionModule psemit = psActivated.emission;
            psemit.enabled = true;
            psActivated.Play();

            if(isTriggered != b)
            {
                StartTrigger();
            }
            isTriggered = true;
        }
        else
        {
            psActivated.Stop();

            if (isTriggered != b)
            {
                ExitTrigger();
            }
            isTriggered = false;
        }
    }

    public virtual void StartTrigger()
    {

    }

    public virtual void ExitTrigger()
    {

    }
}

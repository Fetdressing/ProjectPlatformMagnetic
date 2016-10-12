﻿using UnityEngine;
using System.Collections;

public class GroundChecker : BaseClass {
    public Transform stagObject;
    private CharacterController cController;

    private Transform activePlatform;

    private Vector3 activeGlobalPlatformPoint;
    private Vector3 activeLocalPlatformPoint;

    private Vector3 platformVelocity;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        cController = stagObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        if(activePlatform != null)
        {
            activeGlobalPlatformPoint = activePlatform.position;
            activeLocalPlatformPoint = activePlatform.InverseTransformPoint(stagObject.position);

            Vector3 newGlobalPlatformPoint = activePlatform.TransformPoint(activeLocalPlatformPoint);
            Vector3 moveDistance = newGlobalPlatformPoint - activeGlobalPlatformPoint;

            platformVelocity = moveDistance / Time.deltaTime;

            if(moveDistance != Vector3.zero)
            {
                cController.Move(platformVelocity);
            }
        }
        else
        {
            platformVelocity = Vector3.zero;
        }

        activePlatform = null;
    }

    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "MovingPlatform")
        {
            activePlatform = col.transform;

        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            activePlatform = null;

        }
    }
}
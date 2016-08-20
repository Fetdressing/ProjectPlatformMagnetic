﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    private Transform thisTransform;
    private Camera thisCamera;
    public Transform target;

    [Header("MouseStuff")]
    private float XSensitivity = 18;
    private float YSensitivity = 2;

    public float height = 1f;
    private float distance = 12f;
    private float cameraFollowSpeed = 300;

    private Vector3 offsetX;
    private float offsetHY = 0;
    private Vector3 finalOffset;
    private float distanceOffset = 0;

    private float maxDistanceOffset = 35;
    private float yMinHeight = -25;
    private float yMaxHeight = 25;
    // Use this for initialization
    void Start () {
        thisTransform = this.transform;
        thisTransform.position = target.position + -thisTransform.forward * 10;
        thisCamera = thisTransform.GetComponentsInChildren<Transform>()[1].GetComponent<Camera>();

        offsetX = new Vector3(0, height, distance);
    }

    void LateUpdate()
    {
        float xRot = Input.GetAxis("Mouse X") * XSensitivity;
        float yRot = Input.GetAxis("Mouse Y") * YSensitivity;

        offsetX = Quaternion.AngleAxis(xRot, Vector3.up) * offsetX;
        float yHeightOffset = -yRot;
        offsetHY = Mathf.Clamp(offsetHY + yHeightOffset, yMinHeight, yMaxHeight);
        

        float d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            // scroll up
            distanceOffset -= d* 200 * Time.deltaTime;
        }
        else if (d < 0f)
        {
            // scroll down
            distanceOffset -= d*200 * Time.deltaTime;
        }
        distanceOffset = Mathf.Clamp(distanceOffset, 0, maxDistanceOffset);
        finalOffset = offsetX + new Vector3(0, offsetHY, 0) + thisTransform.forward * Mathf.Abs(offsetHY*0.5f) + -thisTransform.forward * distanceOffset;
        thisTransform.position = Vector3.Lerp(thisTransform.position, target.position + finalOffset, cameraFollowSpeed * Time.deltaTime);
        thisTransform.LookAt(target.position);
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //target.root.GetComponent<Rigidbody>().AddForce(10000 * Time.deltaTime * thisTransform.forward);
            //target.root.GetComponent<Rigidbody>().MovePosition(thisTransform.position + (-thisTransform.forward * Time.deltaTime * -0.003f));
        }
    }

}

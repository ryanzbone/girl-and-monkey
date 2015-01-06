﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public GameObject taya, tiko, currentlyControlled;
    public bool together;
    float  xPosition, zPosition, moveDiff = 0.1f;
    Vector3 oldPosition;
    public GameObject camera;

    // Use this for initialization
    void Start()
    {
        taya = transform.Find("Taya").gameObject;
        tiko = transform.Find("Tiko").gameObject;
        currentlyControlled = taya;
        together = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Mount") && together)
        {
            together = false;
            currentlyControlled = tiko;
            camera.GetComponent<CameraController>().ChangeCharacters();
        }
        else if (Input.GetButtonDown("Mount") && !together && tiko.GetComponent<MonkeyController>().InMountZone)
        {
            together = true;
            currentlyControlled = taya;
            camera.GetComponent<CameraController>().ChangeCharacters();
        }
        if (Input.GetButtonDown("SwapControl") && !together)
        {
            currentlyControlled = (currentlyControlled == taya) ? tiko : taya;
            camera.GetComponent<CameraController>().ChangeCharacters();
        }

        oldPosition = currentlyControlled.transform.position;
        xPosition = oldPosition.x;
        zPosition = oldPosition.z;

        if (Input.GetAxis("Horizontal") > 0.8f)
        {
            xPosition += moveDiff;
        }
        if (Input.GetAxis("Horizontal") < -0.8f)
        {
            xPosition -= moveDiff;
        }
        if (Input.GetAxis("Vertical") > 0.8f)
        {
            zPosition += moveDiff;
        }
        if (Input.GetAxis("Vertical") < -0.8f)
        {
            zPosition -= moveDiff;
        }
        currentlyControlled.transform.position = new Vector3(xPosition, oldPosition.y, zPosition);

        if (together)
        {
            tiko.transform.position = new Vector3(taya.transform.position.x, 2.6f, taya.transform.position.z);
        }
        if (Input.GetButtonDown("Jump") && currentlyControlled == tiko)
        {
            tiko.GetComponent<MonkeyController>().Jump();
        }
    }
}

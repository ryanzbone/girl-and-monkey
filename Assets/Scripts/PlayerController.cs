using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject taya, tiko, currentlyControlled;
    public bool together;
    float  xPosition, zPosition, moveDiff = 0.1f;
    Vector3 oldPosition;
    CameraController cameraController;

    // Use this for initialization
    void Start()
    {
        cameraController = transform.Find("Taya/CameraHook/Camera").GetComponent<CameraController>();
        taya = transform.Find("Taya").gameObject;
        tiko = transform.Find("Tiko").gameObject;
        currentlyControlled = taya;
        together = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyControlled == taya)
        {
            if (Input.GetButtonDown("Grab"))
            {
                taya.GetComponent<TayaController>().Grab();
            }
            if (Input.GetButtonUp("Grab"))
            {
                taya.GetComponent<TayaController>().Release();
            }
        }
        if (currentlyControlled == tiko)
        {
            if (Input.GetButtonDown("Grab"))
            {
                tiko.GetComponent<MonkeyController>().Grab();
            }
            if (Input.GetButtonUp("Grab"))
            {
                tiko.GetComponent<MonkeyController>().Release();
            }
        }

        if (Input.GetButtonDown("Mount") && together)
        {
            together = false;
            currentlyControlled = tiko;
            cameraController.ChangeCharacters();
        }
        else if (Input.GetButtonDown("Mount") && !together && tiko.GetComponent<MonkeyController>().InMountZone)
        {
            together = true;
            currentlyControlled = taya;
            cameraController.ChangeCharacters();
        }
        if (Input.GetButtonDown("SwapControl") && !together)
        {
            currentlyControlled = (currentlyControlled == taya) ? tiko : taya;
            cameraController.ChangeCharacters();
        }

        Movement();
    }

    private void Movement()
    {
        if (currentlyControlled == taya)
        {
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
        }
        else
        {
            tiko.GetComponent<MonkeyController>().Movement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        if (Input.GetButtonDown("Jump") && currentlyControlled == tiko)
        {
            tiko.GetComponent<MonkeyController>().Jump();
        }
    }
}

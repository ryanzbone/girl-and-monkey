using UnityEngine;
using System.Collections;

public class TayaController : MonoBehaviour {

    bool canGrab, grabPressed;
    int grabbedObjectId;
    Transform objectToGrab;

    public void Grab()
    {
        grabPressed = true;
        if(canGrab)
        {
            objectToGrab.parent = transform;
        }
    }

    public void Release()
    {
        grabPressed = false;
        objectToGrab.transform.parent = null;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!canGrab && other.tag == "pushable")
        {
            canGrab = true;
            grabbedObjectId = other.GetInstanceID();
            objectToGrab = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "pushable" && other.GetInstanceID() == grabbedObjectId && canGrab)
        {
            canGrab = false;
            grabbedObjectId = 0;
        }
    }
}

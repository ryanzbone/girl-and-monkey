using UnityEngine;
using System.Collections;

public class MonkeyController : MonoBehaviour {

    public bool inMountZone, canClimb, grabPressed;
    public Vector3 jumpForce = new Vector3(0, 375f, 0);
    Vector3 oldPosition;
    float xPosition, yPosition, zPosition, moveDiff = 0.1f;

    public bool InMountZone { get { return inMountZone; } }

	void Start () {
        inMountZone = true;
	}

	public void Grab()
    {
        grabPressed = true;
    }

    public void Release()
    {
        grabPressed = false;
    }


    void OnTriggerEnter(Collider other)
    {
        inMountZone = other.tag == "MountCollider";

        if (!canClimb && other.tag == "climbable")
        {
            canClimb = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (inMountZone && other.tag == "MountCollider")
            inMountZone = false;
        if (canClimb && other.tag == "climbable")
            canClimb = false;
    }

    public void Jump()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, transform.localScale.y/2))
        {
            if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Terrain") || hitInfo.transform.tag == "Taya")
                rigidbody.AddForce(jumpForce);
        }
    }

    public void Movement(float horizontal, float vertical)
    {
        oldPosition = transform.position;
        xPosition = oldPosition.x;
        yPosition = oldPosition.y;
        zPosition = oldPosition.z;

        if (horizontal > 0.8f)
        {
            xPosition += moveDiff;
        }
        if (horizontal < -0.8f)
        {
            xPosition -= moveDiff;
        }
        if (grabPressed && canClimb)
        {
            rigidbody.useGravity = false;
            if (vertical > 0.8f)
            {
                yPosition += moveDiff;
            }
            if (vertical < -0.8f)
            {
                yPosition -= moveDiff;
            }
        }
        else
        {
            rigidbody.useGravity = true;
            if (vertical > 0.8f)
            {
                zPosition += moveDiff;
            }
            if (vertical < -0.8f)
            {
                zPosition -= moveDiff;
            }
        }
        transform.position = new Vector3(xPosition, yPosition, zPosition);
    }
}

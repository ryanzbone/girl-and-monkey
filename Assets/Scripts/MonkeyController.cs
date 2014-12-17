using UnityEngine;
using System.Collections;

public class MonkeyController : MonoBehaviour {

    public bool inMountZone;
    public Vector3 jumpForce = new Vector3(0, 375f, 0);
    public bool InMountZone { get { return inMountZone; } }
	// Use this for initialization
	void Start () {
        inMountZone = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        inMountZone = other.tag == "MountCollider";
    }

    void OnTriggerExit(Collider other)
    {
        if (inMountZone && other.tag == "MountCollider")
            inMountZone = false;
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
}

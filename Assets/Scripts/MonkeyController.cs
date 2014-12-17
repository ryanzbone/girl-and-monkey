using UnityEngine;
using System.Collections;

public class MonkeyController : MonoBehaviour {

    public bool inMountZone;
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
}

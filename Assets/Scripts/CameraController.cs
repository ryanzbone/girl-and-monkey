using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject tayaHook, tikoHook;
    bool changing;

	void Start () {
        transform.parent = tayaHook.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ChangeCharacters()
    {
        if (transform.parent == tayaHook.transform)
        {
            transform.parent = tikoHook.transform;
            transform.position = tikoHook.transform.position;
        }
        else
        {
            transform.parent = tayaHook.transform;
            transform.position = tayaHook.transform.position;
        }
    }
}

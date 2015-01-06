using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    Transform tayaHook, tikoHook;

	void Start () {
        tayaHook = transform.parent.Find("Taya/CameraHook");
        tikoHook = transform.parent.Find("Tiko/CameraHook");
        transform.parent = tayaHook;
	}
	
    public void ChangeCharacters()
    {
        if (transform.parent == tayaHook)
        {
            transform.parent = tikoHook;
            transform.position = tikoHook.position;
        }
        else
        {
            transform.parent = tayaHook;
            transform.position = tayaHook.position;
        }
    }
}

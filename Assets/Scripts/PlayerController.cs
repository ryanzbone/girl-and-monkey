using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject girl, monkey, currentlyControlled;
    public Vector3 monkeyOffset = new Vector3(2, 0, 2);

	// Use this for initialization
	void Start () {
        girl = transform.Find("Girl").gameObject;
        monkey = transform.Find("Monkey").gameObject;
        currentlyControlled = girl;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 oldPosition = currentlyControlled.transform.position;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentlyControlled = (currentlyControlled == girl) ? monkey : girl;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentlyControlled.transform.position = new Vector3(oldPosition.x + 0.2f, oldPosition.y, oldPosition.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentlyControlled.transform.position = new Vector3(oldPosition.x - 0.2f, oldPosition.y, oldPosition.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentlyControlled.transform.position = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z + 0.2f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentlyControlled.transform.position = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z - 0.2f);
        }
        if (currentlyControlled == girl)
        {
            MonkeyFollows();
        }
	}

    void MonkeyFollows()
    {
        monkey.transform.position = girl.transform.position + monkeyOffset;
    }
}

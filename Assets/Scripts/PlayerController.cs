using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public GameObject taya, tiko, currentlyControlled;
    public bool together;

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
        }
        else if (Input.GetButtonDown("Mount") && !together && tiko.GetComponent<MonkeyController>().InMountZone)
        {
            together = true;
            currentlyControlled = taya;
        }
        if (Input.GetButtonDown("SwapControl") && !together)
        {
            currentlyControlled = (currentlyControlled == taya) ? tiko : taya;
        }

        Vector3 oldPosition = currentlyControlled.transform.position;

        if (Input.GetAxis("Horizontal") > 0.8f)
        {
            currentlyControlled.transform.position = new Vector3(oldPosition.x + 0.2f, oldPosition.y, oldPosition.z);
        }
        if (Input.GetAxis("Horizontal") < -0.8f)
        {
            currentlyControlled.transform.position = new Vector3(oldPosition.x - 0.2f, oldPosition.y, oldPosition.z);
        }
        if (Input.GetAxis("Vertical") > 0.8f)
        {
            currentlyControlled.transform.position = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z + 0.2f);
        }
        if (Input.GetAxis("Vertical") < -0.8f)
        {
            currentlyControlled.transform.position = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z - 0.2f);
        }

        if (together)
        {
            tiko.transform.position = new Vector3(taya.transform.position.x, 2.5f, taya.transform.position.z);
        }
    }
}

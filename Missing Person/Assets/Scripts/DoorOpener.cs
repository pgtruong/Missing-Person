using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpener : MonoBehaviour {

    Animator animator;

    /// <summary>
    /// Bool that represents whether or not the door is open.
    /// </summary>
    [SerializeField] private bool isOpen = false;

    public bool IsDoorOpen
    {
        get { return this.isOpen; }
        set { this.isOpen = value; }
    }
    public Text text;
    float rotation = -60;
    public bool playerCanOpen = false;
    public float doorSpeed = 200f;
    GameObject DoorFrame;


    void Start()
    {
        animator = GetComponent<Animator>();
        DoorFrame = transform.FindChild("Door_Wood").gameObject;
    }   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerCanOpen)
        {
            if (isOpen)
            {
                isOpen = false;
                StopAllCoroutines();
                StartCoroutine(rotateDoor(-rotation));
            }
            else
            {
                isOpen = true;
                StopAllCoroutines();
                StartCoroutine(rotateDoor(rotation));
            }            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCanOpen = true;
            text.enabled = true;
            if (isOpen)
                text.text = "Press E to close door.";
            else
                text.text = "Press E to open door.";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCanOpen = false;
            text.enabled = false;
        }
    }

    /// <summary>
    /// This allows the door to open or close based on the rotation since the animator was not working with this free asset
    /// </summary>
    /// <param name="rotate">Set how you want the door to rotate.</param>
    /// <returns>Makes the door rotate by the rotate param.</returns>
    IEnumerator rotateDoor(float rotate)
    {
        text.enabled = false;
        Vector3 target = new Vector3(DoorFrame.transform.localRotation.x, DoorFrame.transform.localRotation.y, rotate);
        rotate = (rotate < 0) ? rotate + 360 : 0;
        if (!isOpen)
            target = new Vector3(target.x, target.y, 360);
        while (Mathf.Abs(DoorFrame.transform.localEulerAngles.z - rotate) > 5f)
        {
            DoorFrame.transform.localEulerAngles = Vector3.MoveTowards(DoorFrame.transform.localEulerAngles, target, Time.deltaTime * doorSpeed);
            yield return new WaitForEndOfFrame();
        }
        DoorFrame.transform.localEulerAngles = target;
    }
}

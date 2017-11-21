using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    private Quaternion Orig;
    [SerializeField]
    private bool open;
    private bool swinging;
    [SerializeField][Tooltip("True is Right, False is Left")]
    private bool Direction;
    int currentFrame = -1;
    int numOfFrames = 60;


    void Start() {
        Orig = transform.localRotation;
        
    }

    void OnTriggerStay(Collider person) {
        if(person.tag == "Player" && Input.GetAxis("Action") != 0) {
            swinging = true;
        }
    }

    void FixedUpdate() {
        if( currentFrame == -1 && !swinging) {
            currentFrame = 0;
        }
        if(currentFrame >= 0 && currentFrame < numOfFrames) {
            SwingOpen();
            currentFrame = currentFrame + 1;
        }
    }

    void SwingOpen() {
        Vector3 dir;
        if(open) {
            dir = Vector3.up;
        }else {
            dir = Vector3.down;
        }


        if(currentFrame == numOfFrames) {
            Orig = Quaternion.AngleAxis(90, dir);
            transform.rotation = Orig;
            currentFrame = -1;
            open = true;
            swinging = false;
        } else {
            Quaternion newRotation = Quaternion.AngleAxis(90, dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .05f);
        }
    }

}

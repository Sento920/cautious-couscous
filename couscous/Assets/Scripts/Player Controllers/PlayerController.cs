using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction{ UP,DOWN,LEFT,RIGHT,IDLE };

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 move;
    private Direction LastDir;
    private Direction NewDir;
    private Animator Animator;

    [SerializeField]
    private float StealthMod;
    public float movementPower;

    // Use this for initialization
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        LastDir = Direction.IDLE;
        NewDir = Direction.IDLE;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        float x = Input.GetAxis("Horizontal") * (10 * movementPower + 1);
        float y = Input.GetAxis("Vertical") * (10 * movementPower + 1);
        move = new Vector2(x, y);
        Vector2 vDir = rb.transform.InverseTransformDirection(rb.velocity);
        if(vDir.x > 0f) {
            NewDir = Direction.RIGHT;
        } else if(vDir.x < 0f) {
            NewDir = Direction.LEFT;
        }
        if(vDir.y > 0f) {
            NewDir = Direction.UP;
        } else if(vDir.y < 0f) {
            NewDir = Direction.DOWN;
        }

        if(Input.GetButton("Fire2")){
            Debug.Log("Button has been pressed.");
        }
        if(NewDir != LastDir)
            ChangeDir();
    }

    private void FixedUpdate(){
        rb.velocity = move;
    }

    private void ChangeDir() {
        switch(NewDir) {
            case Direction.DOWN:
                LastDir = NewDir;
                Animator.SetBool("Downward", true);
                break;
            case Direction.LEFT:
                LastDir = NewDir;
                Animator.SetBool("Horizontal", true);
                //transform.localScale =new Vector2( -1,1);
                break;
            case Direction.RIGHT:
                LastDir = NewDir;
                Animator.SetBool("Horizontal", true);
                //transform.localScale = new Vector2(1, 1);
                break;
            case Direction.UP:
                LastDir = NewDir;
                Animator.SetBool("Upward", true);
                break;
            
            default:
                break;
        }
    }

}

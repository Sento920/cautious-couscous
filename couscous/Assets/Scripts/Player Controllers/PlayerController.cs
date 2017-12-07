using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction{ UP,DOWN,LEFT,RIGHT,IDLE };

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 move;
    private Animator Animator;

    [SerializeField]
    private float StealthMod;
    public float movementPower;

    // Use this for initialization
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        float x = Input.GetAxis("Horizontal") * (10 * movementPower + 1);
        float y = Input.GetAxis("Vertical") * (10 * movementPower + 1);
        move = new Vector2(x, y);
        setAnimation();
    }

    private void FixedUpdate(){
        rb.velocity = move;
    }

    private void setAnimation(){
        Vector2 vDir = rb.transform.InverseTransformDirection(rb.velocity);
        Animator.SetFloat("Vert",vDir.normalized.y);
        Animator.SetFloat("Horiz",Mathf.Abs(vDir.normalized.x));
        if(vDir.normalized.x > 0){
            GetComponent<SpriteRenderer>().flipX = false;
        }else{
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMove : MonoBehaviour {

    [SerializeField]
    private Vector2 Target;
    [SerializeField]
    private float oomph;
    private Rigidbody2D rb;
    Vector2 currHeading;
    bool shouldMove;

    private void Start() {
        shouldMove = false;
        this.rb = GetComponent<Rigidbody2D>();
        currHeading = new Vector2(); 
        Target = new Vector2();
    }

    private void FixedUpdate() {
        if(shouldMove) {
            //this.transform.LookAt(currHeading, Vector2.up);
            transform.up = currHeading - (Vector2) transform.position;
            rb.velocity = transform.up * (oomph + .1f);
        }
    }

    public void MoveToward() {
        currHeading = Vector2.Lerp(this.transform.position, Target, Time.deltaTime);
        
    }

    public bool isMoving() {
        return shouldMove;
    }

    public void Move(bool _val) {
        shouldMove = _val;
    }

    public void SetTarget(Vector2 target) {
        this.Target = target; 
    }

    public Vector2 getTarget() {
        return Target;
    }

    

}

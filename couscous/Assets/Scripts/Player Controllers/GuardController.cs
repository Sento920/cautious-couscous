using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE { IDLE,ATTACK,ENROUTE,INVESTIGATE,PATROL,CAUTION};

public class GuardController : MonoBehaviour {

    string OriginalName;

    //References We need
    private GameObject GameController;
    private Pathfinder pathFinder;
    private STATE State;
    PolygonCollider2D VisionCone;
    private Pathfinder path;
    
    //Movement
    EasyMove guard;
    [SerializeField]
    private List<Vector2> patrolPath;
    int patrolMarker;

    //Lists of Tags
    public List<string> SafeTags;
    public List<string> CautionTags;
    
    //Other Variables That cannot be derived.
    [SerializeField]
    float DetectDistance;
    [SerializeField]
    float pathAccuracy;
    bool foundSomething;
    private Tuple<Vector2, GameObject> Target;
    
    //timer stuff
    [SerializeField]
    float Duration;
    float timeLeft;

    // Use this for initialization
    void Start () {
        OriginalName = this.name;
        guard = GetComponent<EasyMove>();
        VisionCone = GetComponent<PolygonCollider2D>();
        State = STATE.IDLE;
        patrolMarker = 0;
        Target = new Tuple<Vector2, GameObject>();
        GameController = GameObject.FindWithTag("GameController");
        pathFinder = GameController.GetComponent<Pathfinder>();
        SetTarget(patrolPath[patrolMarker], gameObject);
        guard.Move(true);
    }
	
	// Update is called once per frame
	void Update () {
        Patrol();
	}

    public void SetTarget(Vector2 loc, GameObject obj) {
        Target.setOne(loc);
        Target.setTwo(obj);
        guard.SetTarget(loc);
    }

    private void Patrol() {
        if(Vector2.Distance(transform.position,patrolPath[patrolMarker]) < pathAccuracy) {
            //We've arrived, Set a new Target.
            if(patrolMarker < patrolPath.Count-1) {
                patrolMarker++;
            } else {
                patrolMarker = 0;
            }
            SetTarget(patrolPath[patrolMarker], this.gameObject);
        } else {
            //Target Not Reached
            guard.MoveToward();
        }
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        for(int i = 1; i < patrolPath.Count; i++) {
            Gizmos.DrawLine(patrolPath[i-1], patrolPath[i]);
        }
        Gizmos.DrawLine(patrolPath[patrolPath.Count-1], patrolPath[0]);
    }

}

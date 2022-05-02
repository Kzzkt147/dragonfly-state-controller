using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
The enemy controller is the main controller that controls what state the enemy is in.
It will run the Update and Start functions of the current state only.
*/


public class EnemyController : MonoBehaviour {

    public EnemyStats stats;
    public State currentState;

    public float seeDistance;
    public LayerMask enemyLayers;

    [HideInInspector] public Transform target;
    public Rigidbody2D myRigidbody;

    private void Start() {
        currentState.StartState(this);
    }

    private void Update() {
        currentState.UpdateState(this);
    }
    
    private void FixedUpdate() {
        currentState.FixedUpdateState(this);
    }

    public void ChangeState(State nextState) {
        currentState = nextState;
        currentState.StartState(this);
    }


    public bool CanSeeTarget() {
        Collider2D[] viewableTargets = Physics2D.OverlapCircleAll(transform.position, seeDistance, enemyLayers);
        if(viewableTargets.Length != 0) {
            target = viewableTargets[0].transform;
            return true;
        } 
        else return false;

    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, seeDistance);
    }
}

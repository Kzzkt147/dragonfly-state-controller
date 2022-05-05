using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
The enemy controller is the main controller that controls what state the enemy is in.
It will run the Update and Start functions of the current state only.
*/


public class EnemyController : MonoBehaviour {

    [Header("Enemy Stats")]
    public EnemyStats stats;

    [Header("State")]
    public State currentState;

    [Header("Targetting")]
    public float seeDistance;
    public float attackDistance;
    public LayerMask enemyLayers;
    
    [HideInInspector] public bool canAttack = true;
    private float _cooldownTimer;

    [HideInInspector] public Transform target;
    [HideInInspector] public Rigidbody2D myRigidbody;

    private void Awake() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        currentState.StartState(this);
    }

    private void Update() {
        currentState.UpdateState(this);
        
        HandleAttackCooldown();
    }
    
    private void FixedUpdate() {
        currentState.FixedUpdateState(this);
    }

    public void ChangeState(State nextState) {
        currentState = nextState;
        currentState.StartState(this);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, seeDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

    private void HandleAttackCooldown() {
        if(!canAttack) {
            _cooldownTimer += Time.deltaTime;

            if(_cooldownTimer >= stats.attackDelay) {
                _cooldownTimer = 0;
                canAttack = true;
            }
        }
    }
}

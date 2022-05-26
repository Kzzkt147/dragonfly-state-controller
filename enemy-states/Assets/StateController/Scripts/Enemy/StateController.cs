using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[RequireComponent(typeof(Rigidbody2D))]
public class StateController : MonoBehaviour {

    public BehaviourGraph graph;

    [Header("Targeting")]
    public LayerMask targetLayers;
    public float seeRadius;
    [HideInInspector] public Transform target;

    [Header("Attacking")]
    public float attackRadius;
    [HideInInspector] public bool inAttackRange = false;

    [Header("Movement")]
    public float runSpeed = 3f;
    [HideInInspector] public Vector2 direction;

    //REFERENCES
    [HideInInspector] public Rigidbody2D rigidBody;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // check for conditionals
        CheckForTarget();
        CheckAttackRange();

    }

    private void CheckForTarget() {
        Collider2D targetCollider = Physics2D.OverlapCircle(transform.position, seeRadius, targetLayers);

        if(targetCollider != null) {
            target = targetCollider.transform;
        }
        else {
            target = null;
        }
    }

    private void CheckAttackRange() {
        if(target != null) {
            Collider2D targetCollider = Physics2D.OverlapCircle(transform.position, attackRadius, targetLayers);
            if(targetCollider != null) {
                inAttackRange = true;
            }
            else {
                inAttackRange = false;
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, seeRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
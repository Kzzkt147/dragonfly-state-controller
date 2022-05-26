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
        
        // update current nodes actions and transitions
        graph.currentNode.UpdateActions(this);
        graph.currentNode.UpdateTransitions(this);
    }
    private void FixedUpdate() {
        // update current nodes actions
        graph.currentNode.FixedUpdateActions(this);
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

    #region Nodes
    private void Start() {
        // check all nodes for the start node and set the graphs current node to it
        foreach(BaseNode node in graph.nodes) {
            if(node is StartNode) {
                graph.currentNode = node;
                break;
            }
        }

        StartCoroutine(ParseNode());
    }

    private IEnumerator ParseNode() {

        switch (graph.currentNode) {

            case StartNode _:
                NextNode("exit");
                break;
            case StateNode _:
                StateNode currentNode = graph.currentNode as StateNode;
                graph.currentNode = currentNode;
                graph.currentNode.StartActions(this);
                break;
        }

        yield return null;
    }

    public void NextNode(string portFieldName) {
        // change current node to the node that is connected to 'portFieldName' port
        foreach(NodePort port in graph.currentNode.Ports) {
            if(port.fieldName == portFieldName) {
                graph.currentNode = port.Connection.node as BaseNode;
                StartCoroutine(ParseNode());
                break;
            }
        }
        
    }
    #endregion

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, seeRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
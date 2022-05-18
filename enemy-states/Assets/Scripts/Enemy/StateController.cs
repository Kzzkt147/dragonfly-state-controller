using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class StateController : MonoBehaviour {

    public BehaviourGraph graph;

    [Header("Targetting")]
    public LayerMask targetLayers;
    public float seeRadius;
    public Transform target;

    private void Update() {
        CheckForTarget();
        graph.currentNode.UpdateActions(this);
        graph.currentNode.UpdateTransitions(this);
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
    
    #region Nodes
    private void Start() {
        // check all nodes for the start node and set the graphs current node to it
        foreach(BaseNode node in graph.nodes) {
            if(node.GetString() == "Start") {
                graph.currentNode = node;
                break;
            }
        }

        StartCoroutine(ParseNode());
    }

    private IEnumerator ParseNode() {
        string data = graph.currentNode.GetString();

        switch (data) {

            case "Start":
                NextNode("exit");
                break;
            case "State":
                StateNode currentNode = graph.currentNode as StateNode;
                graph.currentNode = currentNode;
                graph.currentNode.StartActions(this);
                break;
            case "End":
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
    }
}
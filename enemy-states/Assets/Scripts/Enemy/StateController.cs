using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class StateController : MonoBehaviour {

    public BehaviourGraph graph;


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
                yield return new WaitUntil(() => currentNode.transition.decision.HandleDecision(this) == true);
                break;
            case "End":
                break;
        }

        return null;
    }

    private void NextNode(string portFieldName) {
        // change current node to the node that is connected to 'portFieldName' port
        foreach (NodePort port in graph.currentNode.Ports) {
            if(port.fieldName == portFieldName) {
                graph.currentNode = port.Connection.node as BaseNode;
                break;
            }
        }
    }
}

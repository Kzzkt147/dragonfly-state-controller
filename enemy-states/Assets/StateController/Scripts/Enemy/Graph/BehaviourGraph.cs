using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class BehaviourGraph : NodeGraph {
    public BaseNode currentNode;


    public void StartGraph(StateController controller) {
        // check all nodes for the start node and set the graphs current node to it
        foreach(BaseNode node in nodes) {
            if(node is StartNode) {
                currentNode = node;
                break;
            }
        }

        currentNode.ParseNode(controller, this);
    }

    public void UpdateGraph(StateController controller) {
        currentNode.UpdateActions(controller);
        currentNode.UpdateTransitions(controller);
    }

    public void FixedUpdateGraph(StateController controller) {
        currentNode.FixedUpdateActions(controller);
    }

    public void NextNode(StateController controller, string portFieldName) {

        // change current node to the node that is connected to 'portFieldName' port
        foreach(NodePort port in currentNode.Ports) {
            if(port.fieldName == portFieldName) {
                currentNode = port.Connection.node as BaseNode;
                currentNode.ParseNode(controller, this);
                break;
            }
        }

    }
}
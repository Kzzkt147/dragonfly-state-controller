using System.Linq;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class BehaviourGraph : NodeGraph 
{
    public BaseNode currentNode;
    
    public void StartGraph(EnemyController controller)
    {
        // check all nodes for the start node and set the graphs current node to it
        foreach (var node in nodes.OfType<StartNode>())
        {
            currentNode = node;
            break;
        }
        currentNode.ParseNode(controller, this);
    }

    public void UpdateGraph(EnemyController controller) 
    {
        currentNode.UpdateActions(controller);
        currentNode.UpdateTransitions(controller);
    }

    public void FixedUpdateGraph(EnemyController controller) 
    {
        currentNode.FixedUpdateActions(controller);
    }

    public void NextNode(EnemyController controller, string portFieldName) 
    {
        // change current node to the node that is connected to 'portFieldName' port
        foreach(var port in currentNode.Ports)
        {
            if (port.fieldName != portFieldName) continue;
            currentNode = port.Connection.node as BaseNode;
            if (currentNode is null) return;
            currentNode.ParseNode(controller, this);
            break;
        }
    }
}
public class StateNode : BaseNode 
{
    [Input] public int entry;

    public Action action;

    [Output(dynamicPortList = true)] public Decision[] decisions;

    // setup of the node
    public override void ParseNode(EnemyController controller, BehaviourGraph graph)
    {
        graph.currentNode = graph.currentNode as StateNode;
        if (graph.currentNode != null) graph.currentNode.StartActions(controller);
    }
    
    public override void StartActions(EnemyController controller)
    {
        action.StartActions(controller);
    }
    
	public override void UpdateActions(EnemyController controller)
    {
        action.UpdateActions(controller);
    }
    
    public override void FixedUpdateActions(EnemyController controller)
    {
        action.FixedUpdateActions(controller);
    }
    
    public override void UpdateTransitions(EnemyController controller)
    {
        // for every decision, check if any of them are true - if so, change to state it's connected to
        for(var i = 0; i < decisions.Length; i++)
        {
            if (!decisions[i].HandleDecision(controller)) continue;
            controller.graph.NextNode(controller, "decisions " + i);
            return;
        }
    }
}

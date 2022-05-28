public class StartNode : BaseNode 
{
    [Output] public int exit;

    // setup the node
    public override void ParseNode(EnemyController controller, BehaviourGraph graph) 
    {
        graph.NextNode(controller, "exit");
    }
}

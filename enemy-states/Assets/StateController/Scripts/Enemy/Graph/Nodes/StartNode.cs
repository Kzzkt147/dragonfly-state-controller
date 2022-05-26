public class StartNode : BaseNode 
{
    [Output] public int exit;

    // will setup the node when called
    public override void ParseNode(EnemyController controller, BehaviourGraph graph) 
    {
        graph.NextNode(controller, "exit");
    }
}

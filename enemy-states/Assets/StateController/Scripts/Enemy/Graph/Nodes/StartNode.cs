using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : BaseNode {

	[Output] public int exit;

    // will setup the node when called
    public override void ParseNode(StateController controller, BehaviourGraph graph) {
        graph.NextNode(controller, "exit");
    }
}

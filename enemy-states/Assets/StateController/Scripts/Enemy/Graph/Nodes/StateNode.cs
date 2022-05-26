using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class StateNode : BaseNode {
    
    [Input] public int entry;

    public Action action;

    [Output(dynamicPortList = true)] public Decision[] decisions;
	
    
    // will update any actions and transitions of the node when active
    public override void StartActions(StateController controller) {
        action.StartActions(controller);
    }
	public override void UpdateActions(StateController controller) {
        action.UpdateActions(controller);
    }
    public override void FixedUpdateActions(StateController controller) {
        action.FixedUpdateActions(controller);
    }
    public override void UpdateTransitions(StateController controller) {

        for(int i = 0; i < decisions.Length; i++) {
            if(decisions[i].HandleDecision(controller)) {
                controller.NextNode("decisions " + i);
                return;
            }
        }
    }
}

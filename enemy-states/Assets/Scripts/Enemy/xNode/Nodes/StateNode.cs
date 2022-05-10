using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class StateNode : BaseNode {
    
    [Input] public int entry;

    public Action[] actions;

    public Transition[] transitions;


    // return info on current node
    public override string GetString() {
		return "State";
	}

	
    
    // will update any actions and transitions of the node when active
	public override void UpdateActions() {

    }
	public override void UpdateTransitions() {

    }
}

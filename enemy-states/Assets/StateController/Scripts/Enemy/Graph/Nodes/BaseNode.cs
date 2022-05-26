using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class BaseNode : Node {


	// default implimentation of xnode method -- can ignore
	public override object GetValue(NodePort port) {
		return null;
	}

	public abstract void ParseNode(StateController controller, BehaviourGraph graph);

	// will update any actions and transitions of the node when active
	public virtual void StartActions(StateController controller) {

    }
	public virtual void UpdateActions(StateController controller) {

    }
	public virtual void FixedUpdateActions(StateController controller) {

    }
	public virtual void UpdateTransitions(StateController controller) {

    }
}
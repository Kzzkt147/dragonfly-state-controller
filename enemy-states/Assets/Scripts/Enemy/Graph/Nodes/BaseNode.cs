using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class BaseNode : Node {

	// return info on current node
	public virtual string GetString() {
		return null;
	}
	

	// default implimentation of xnode method -- can ignore
	public override object GetValue(NodePort port) {
		return null;
	}

	// will update any actions and transitions of the node when active
	public abstract void StartActions(StateController controller);
	public abstract void UpdateActions(StateController controller);
	public abstract void FixedUpdateActions(StateController controller);
	public abstract void UpdateTransitions(StateController controller);
}
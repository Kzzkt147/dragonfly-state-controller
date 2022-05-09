using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : BaseNode {

	[Output] public int exit;

    public override string GetString() {
		return "Start";
	}

	// will update any actions and transitions of the node when active
	public override void UpdateActions() {

    }
	public override void UpdateTransitions() {

    }

}

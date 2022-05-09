using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNode : BaseNode
{
	[Input] public int entry;

    public override string GetString() {
		return "End";
	}

	// will update any actions and transitions of the node when active
	public override void UpdateActions() {

    }
	public override void UpdateTransitions() {

    }
}

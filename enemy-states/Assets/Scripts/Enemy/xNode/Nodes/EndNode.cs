using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNode : BaseNode
{
	[Input] public int entry;

    public override string GetString() {
		return "End";
	}

    public override void StartActions(StateController controller) {
    }

    public override void UpdateActions(StateController controller) {
    }

    public override void UpdateTransitions(StateController controller) {
    }
}

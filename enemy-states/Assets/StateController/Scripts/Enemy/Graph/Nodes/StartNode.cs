using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : BaseNode {

	[Output] public int exit;



    public override string GetString() {
		return "Start";
	}

    public override void StartActions(StateController controller) {
    }

    public override void UpdateActions(StateController controller) {
    }

    public override void FixedUpdateActions(StateController controller) {
        
    }

    public override void UpdateTransitions(StateController controller) {
    }
}

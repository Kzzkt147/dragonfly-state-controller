using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class StateNode : BaseNode {

	public Action action;

	public void UpdateAction(EnemyController controller) {
		action.UpdateAction(controller);
	}
}
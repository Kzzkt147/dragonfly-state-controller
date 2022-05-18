using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/ChaseAction", fileName = "ChaseAction")]
public class ChaseAction : Action {

    public override void StartActions(StateController controller) {
        Debug.Log("Entered Chase State");
    }

    public override void UpdateActions(StateController controller) {
        Debug.Log("Chasing");
    }

    public override void FixedUpdateActions(StateController controller) {
        
    }

}

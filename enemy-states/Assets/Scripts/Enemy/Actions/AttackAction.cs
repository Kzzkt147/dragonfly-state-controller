using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/AttackAction", fileName = "AttackAction")]
public class AttackAction : Action {

    public override void StartActions(StateController controller) {
        Debug.Log("Entered attack state");
    }

    public override void UpdateActions(StateController controller) {
        
    }

    public override void FixedUpdateActions(StateController controller) {
        
    }
}

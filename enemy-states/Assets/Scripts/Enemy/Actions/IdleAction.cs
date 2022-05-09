using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IdleAction")]
public class IdleAction : Action {

    public override void StartActions(StateController controller) {
        Debug.Log("Entered Idle");
    }
    public override void UpdateActions(StateController controller) {
        Debug.Log("Idle");
    }
    public override void FixedUpdateActions(StateController controller) {

    }
}

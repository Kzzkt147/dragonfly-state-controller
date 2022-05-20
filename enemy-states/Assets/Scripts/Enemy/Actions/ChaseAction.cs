using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/ChaseAction", fileName = "ChaseAction")]
public class ChaseAction : Action {

    public override void StartActions(StateController controller) {
        Debug.Log("Entered Chase State");
    }

    public override void UpdateActions(StateController controller) {
        if(controller.target == null) return;
        controller.direction = ((Vector2)controller.target.position - controller.rigidBody.position).normalized;
    }

    public override void FixedUpdateActions(StateController controller) {
        controller.rigidBody.MovePosition(controller.rigidBody.position + controller.direction * controller.runSpeed * Time.fixedDeltaTime);
    }

}

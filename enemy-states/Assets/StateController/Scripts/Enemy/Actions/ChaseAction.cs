using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/ChaseAction", fileName = "ChaseAction")]
public class ChaseAction : Action {
    
    public override void StartActions(EnemyController controller)
    {
        Debug.Log("Entered Chase State");
    }

    public override void UpdateActions(EnemyController controller)
    {
        // if we have a target, get the direction to it
        if(controller.target == null) return;
        controller.direction = ((Vector2)controller.target.position - controller.rigidBody.position).normalized;
    }

    public override void FixedUpdateActions(EnemyController controller)
    {
        // move towards our direction
        controller.rigidBody.MovePosition(controller.rigidBody.position + controller.direction * (controller.runSpeed * Time.fixedDeltaTime));
    }
}

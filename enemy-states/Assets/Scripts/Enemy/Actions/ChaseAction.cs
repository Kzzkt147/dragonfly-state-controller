using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/ChaseAction")]
public class ChaseAction : Action {

    public override void StartAction(EnemyController controller) {
        Debug.Log("Entered Chase State");
    }
    public override void UpdateAction(EnemyController controller) {
        Debug.Log("In Chase");   
    }

    public override void FixedUpdateAction(EnemyController controller) {
        Vector3 direction = (controller.transform.position - controller.target.transform.position).normalized;
        controller.myRigidbody.MovePosition(controller.transform.position - direction * controller.stats.runSpeed * Time.fixedDeltaTime);
    }
}

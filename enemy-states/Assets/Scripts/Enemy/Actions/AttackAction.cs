using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/AttackAction")]
public class AttackAction : Action {

    public override void StartAction(EnemyController controller) {
        Debug.Log("Entered Attack State");
    }
    public override void UpdateAction(EnemyController controller) {
        if(controller.canAttack) {
            if(controller.target.GetComponent<ITakeDamage>() == null) return;

            controller.target.GetComponent<ITakeDamage>().TakeDamage(controller.stats.damage);
            controller.canAttack = false;
        }
    }
    public override void FixedUpdateAction(EnemyController controller) {

    }

}

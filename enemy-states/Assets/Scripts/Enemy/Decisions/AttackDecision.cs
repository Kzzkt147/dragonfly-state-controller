using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/AttackDecision")]
public class AttackDecision : Decision {

    public override bool HandleDecision(EnemyController controller) {
        return InAttackRange(controller);
    }

    private bool InAttackRange(EnemyController controller) {
        Collider2D[] attackableTargets = Physics2D.OverlapCircleAll(controller.transform.position, controller.attackDistance, controller.enemyLayers);
        if(attackableTargets.Length != 0) {
            controller.target = attackableTargets[0].transform;
            return true;
        } 
        else return false;
    }

}

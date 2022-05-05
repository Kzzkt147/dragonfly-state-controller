using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/SeeDecision")]
public class SeeDecision : Decision {

    public override bool HandleDecision(EnemyController controller) {
        return CanSeeTarget(controller);
    }

    private bool CanSeeTarget(EnemyController controller) {
        Collider2D[] viewableTargets = Physics2D.OverlapCircleAll(controller.transform.position, controller.seeDistance, controller.enemyLayers);
        if(viewableTargets.Length != 0) {
            controller.target = viewableTargets[0].transform;
            return true;
        } 
        else return false;
    }
 
}

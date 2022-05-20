using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/InAttackRangeDecision", fileName = "InAttackRangeDecision")]
public class InAttackRangeDecision : Decision {
    public override bool HandleDecision(StateController controller) {
        if(controller.inAttackRange) return true;
        else return false;
    }
}

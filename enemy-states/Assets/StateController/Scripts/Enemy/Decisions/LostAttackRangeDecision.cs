using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/LostAttackRangeDecision", fileName = "LostAttackRangeDecision")]
public class LostAttackRangeDecision : Decision {
    public override bool HandleDecision(StateController controller) {
        if(controller.inAttackRange == false) return true;
        else return false;
    }
}

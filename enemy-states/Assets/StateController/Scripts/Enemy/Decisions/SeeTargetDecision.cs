using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/SeeTargetDecision", fileName = "SeeTargetDecision")]
public class SeeTargetDecision : Decision {
    public override bool HandleDecision(StateController controller) {
        if(controller.target == null) return false;
        else return true;
    }
}

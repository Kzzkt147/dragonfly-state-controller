using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/LostTargetDecision", fileName = "LostTargetDecision")]
public class LostTargetDecision : Decision {
    public override bool HandleDecision(StateController controller) {
        if(controller.target == null) return true;
        else return false;
    }
}

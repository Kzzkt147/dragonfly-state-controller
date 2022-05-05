using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/SeeDecision")]
public class SeeDecision : Decision {

    public override bool HandleDecision(EnemyController controller) {
        
        if(controller.CanSeeTarget()) {
            return true;
        }
        
        return false;
    }
 
}

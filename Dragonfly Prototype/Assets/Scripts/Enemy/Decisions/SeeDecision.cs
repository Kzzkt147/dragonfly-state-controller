using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/SeeDecision")]
public class SeeDecision : Decision {

    public override bool HandleDecision(EnemyController controller) {
        //CODE TO CHECK IF ENEMY SEES TARGET - IF IT DOES, RETURN TRUE - ELSE RETURN FALSE
        
        return false;
    }
 
}

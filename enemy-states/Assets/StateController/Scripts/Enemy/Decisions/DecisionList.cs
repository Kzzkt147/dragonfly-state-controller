using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/DecisionList", fileName = "DecisionList")]
public class DecisionList : Decision {

    public Decision[] decisionList;

    public override bool HandleDecision(StateController controller) {

        foreach(Decision decision in decisionList) 
            if(!decision.HandleDecision(controller))
                return false;

        return true;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/DecisionList", fileName = "DecisionList")]
public class DecisionList : Decision {

    public Decision[] decisionList;

    public override bool HandleDecision(StateController controller) {

        int trueDecisions = 0;
        
        for(int i = 0; i < decisionList.Length; i++) {
            if(decisionList[i].HandleDecision(controller)) trueDecisions++;
        }
        if(trueDecisions == decisionList.Length) return true;
        else return false;
    }
}

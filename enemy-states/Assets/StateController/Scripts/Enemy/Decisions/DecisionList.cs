using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/DecisionList", fileName = "DecisionList")]
public class DecisionList : Decision 
{
    public Decision[] decisionList;

    public override bool HandleDecision(EnemyController controller) 
    {
        foreach(var decision in decisionList) 
            if(!decision.HandleDecision(controller))
                return false;

        return true;
    }
}

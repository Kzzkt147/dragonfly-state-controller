using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/SeeTargetDecision", fileName = "SeeTargetDecision")]
public class SeeTargetDecision : Decision 
{
    public override bool HandleDecision(EnemyController controller)
    {
        return controller.target != null;
    }
}

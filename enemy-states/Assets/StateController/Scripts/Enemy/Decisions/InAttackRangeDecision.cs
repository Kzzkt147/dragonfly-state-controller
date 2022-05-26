using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/InAttackRangeDecision", fileName = "InAttackRangeDecision")]
public class InAttackRangeDecision : Decision 
{
    public override bool HandleDecision(EnemyController controller)
    {
        return controller.inAttackRange;
    }
}

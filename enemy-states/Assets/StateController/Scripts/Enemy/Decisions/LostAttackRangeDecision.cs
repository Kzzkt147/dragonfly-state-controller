using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/LostAttackRangeDecision", fileName = "LostAttackRangeDecision")]
public class LostAttackRangeDecision : Decision 
{
    public override bool HandleDecision(EnemyController controller)
    {
        return controller.inAttackRange == false;
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/LostTargetDecision", fileName = "LostTargetDecision")]
public class LostTargetDecision : Decision 
{
    public override bool HandleDecision(EnemyController controller)
    {
        return controller.target == null;
    }
}

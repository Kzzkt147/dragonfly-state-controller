using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/AttackAction", fileName = "AttackAction")]
public class AttackAction : Action 
{
    public override void StartActions(EnemyController controller)
    {
        Debug.Log("Entered attack state");
    }

    public override void UpdateActions(EnemyController controller)
    {
        
    }

    public override void FixedUpdateActions(EnemyController controller)
    {
        
    }
}

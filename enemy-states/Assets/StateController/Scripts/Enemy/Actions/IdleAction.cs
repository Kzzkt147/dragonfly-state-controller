using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/IdleAction", fileName = "IdleAction")]
public class IdleAction : Action
{
    public override void StartActions(EnemyController controller)
    {
        Debug.Log("Entered Idle");
    }
    public override void UpdateActions(EnemyController controller)
    {
        
    }
    public override void FixedUpdateActions(EnemyController controller)
    {

    }
}

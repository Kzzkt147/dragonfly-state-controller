using UnityEngine;

public abstract class Action : ScriptableObject 
{
    public abstract void StartActions(EnemyController controller);
    public abstract void UpdateActions(EnemyController controller);
    public abstract void FixedUpdateActions(EnemyController controller);

}

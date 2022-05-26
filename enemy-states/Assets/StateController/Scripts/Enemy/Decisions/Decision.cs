using UnityEngine;

public abstract class Decision : ScriptableObject 
{
    public abstract bool HandleDecision(EnemyController controller);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject {


    public abstract void StartAction(EnemyController controller);
    public abstract void UpdateAction(EnemyController controller);
    public abstract void FixedUpdateAction(EnemyController controller);

}

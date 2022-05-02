using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/Actions/IdleAction")]
public class IdleAction : Action {

    public override void StartAction(EnemyController controller)
    {
        Debug.Log("Entered Idle State");
    }

    public override void UpdateAction(EnemyController controller) {
        Debug.Log("In Idle");
    }
}

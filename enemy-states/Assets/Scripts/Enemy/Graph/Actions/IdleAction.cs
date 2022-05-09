using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : Action {

    public override void UpdateAction(EnemyController controller) {
        Debug.Log("Idle");
    }

}

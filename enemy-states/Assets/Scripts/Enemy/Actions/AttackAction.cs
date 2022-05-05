using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/AttackAction")]
public class AttackAction : Action {

    public override void StartAction(EnemyController controller) {
        Debug.Log("Entered Attack State");
    }
    public override void UpdateAction(EnemyController controller) {
        Debug.Log("In Attack");
    }
    public override void FixedUpdateAction(EnemyController controller) {

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Each State holds an Action and Condition. It will continuosly run the Action in Update and will also check for any conditions to transition from
one state to the next.
*/


[CreateAssetMenu(menuName = "Enemy/State")]
public class State : ScriptableObject {

    public Action action;
    public Transition transition;

    public void StartState(EnemyController controller) {
        action.StartAction(controller);
    }

    public void UpdateState(EnemyController controller) {
        action.UpdateAction(controller);
    }

    public bool UpdateDecision(EnemyController controller) {
        return transition.decision.HandleDecision(controller);
    }

}

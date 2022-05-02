using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Each State holds an Action and Transition. It will continuosly run the Action in Update and will also check for any conditions to transition from
one state to the next.
*/


[CreateAssetMenu(menuName = "Enemy/State")]
public class State : ScriptableObject {

    public Action[] actions;
    public Transition[] transitions;

    public void StartState(EnemyController controller) {
        for (int i = 0; i < actions.Length; i++) {
            actions[i].StartAction(controller);
        }
    }

    public void UpdateState(EnemyController controller) {
        for (int i = 0; i < actions.Length; i++) {
            actions[i].UpdateAction(controller);
        }

        CheckForTransitions(controller);
    }

    private void CheckForTransitions(EnemyController controller) {
        
        foreach (var transition in transitions) {
            bool decision = transition.decision.HandleDecision(controller);
            
            if(decision) {
                if(transition.trueState == null) return;
                controller.ChangeState(transition.trueState);
            } 
            else {
                if(transition.falseState == null) return;
                controller.ChangeState(transition.falseState);
            } 
        }
    }

}

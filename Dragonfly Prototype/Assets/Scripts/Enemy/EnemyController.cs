using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
The enemy controller is the main controller that controls what state the enemy is in.
It will run the Update and Start functions of the current state only.
*/


public class EnemyController : MonoBehaviour {

    public EnemyStats stats;
    public State currentState;


    private void Start() {
        currentState.StartState(this);
    }

    private void Update() {
        currentState.UpdateState(this);
        HandleConditional();
        

    }

    private void ChangeState(State nextState) {
        currentState = nextState;
        currentState.StartState(this);
    }

    private void HandleConditional() {
        if(currentState.UpdateDecision(this)) {
            
            if(currentState.transition.trueState == null) return;
            ChangeState(currentState.transition.trueState);
        } 
        else {
            
            if(currentState.transition.falseState == null) return;
            ChangeState(currentState.transition.falseState);
        }
    }
}

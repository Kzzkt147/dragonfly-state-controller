using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LookDecision")]
public class LookDecision : Decision {
    
    public override bool HandleDecision(StateController controller) {
        return false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject {

    public abstract void StartActions(StateController controller);
    public abstract void UpdateActions(StateController controller);
    public abstract void FixedUpdateActions(StateController controller);

}

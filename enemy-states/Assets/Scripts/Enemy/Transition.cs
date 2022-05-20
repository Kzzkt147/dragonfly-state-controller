using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[System.Serializable]
public class Transition {

    public Decision decision;

    [Node.Output] public int trueState;
}

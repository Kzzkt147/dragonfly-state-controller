using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BaseNode : Node {
    
    public virtual string GetString() {
        return null;
    }

    public override object GetValue(NodePort port) {
        return null;
    }

}

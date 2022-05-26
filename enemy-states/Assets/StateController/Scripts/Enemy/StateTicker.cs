using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateController))]
public class StateTicker : MonoBehaviour {

    private BehaviourGraph _graph;
    private StateController _controller;

    private void Awake() {
        _controller = GetComponent<StateController>();
        _graph = _controller.graph;
    }

    private void Start() => _graph.StartGraph(_controller);

    private void Update() => _graph.UpdateGraph(_controller);

    private void FixedUpdate() => _graph.FixedUpdateGraph(_controller);

}

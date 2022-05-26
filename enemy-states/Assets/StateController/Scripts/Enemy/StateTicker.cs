using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class StateTicker : MonoBehaviour 
{
    private BehaviourGraph _graph;
    private EnemyController _controller;

    private void Awake() 
    {
        _controller = GetComponent<EnemyController>();
        _graph = _controller.graph;
    }

    private void Start() => _graph.StartGraph(_controller);

    private void Update() => _graph.UpdateGraph(_controller);

    private void FixedUpdate() => _graph.FixedUpdateGraph(_controller);

}

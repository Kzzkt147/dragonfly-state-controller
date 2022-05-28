using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour 
{
    public BehaviourGraph graph;

    [Header("Targeting")]
    public LayerMask targetLayers;
    public float seeRadius;
    [HideInInspector] public Transform target;

    [Header("Attacking")]
    public float attackRadius;

    [HideInInspector] public bool inAttackRange;

    [Header("Movement")]
    public float runSpeed = 3f;
    [HideInInspector] public Vector2 direction;

    //REFERENCES
    [HideInInspector] public Rigidbody2D rigidBody;

    private void Awake() 
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        // check for conditionals
        CheckForTarget();
        CheckAttackRange();

    }

    private void CheckForTarget()
    {
        var targetCollider = Physics2D.OverlapCircle(transform.position, seeRadius, targetLayers);

        target = targetCollider != null ? targetCollider.transform : null;
    }

    private void CheckAttackRange()
    {
        if (target == null) return;
        var targetCollider = Physics2D.OverlapCircle(transform.position, attackRadius, targetLayers);
        inAttackRange = targetCollider != null;
    }

    private void OnDrawGizmosSelected() {
        var position = transform.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(position, seeRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(position, attackRadius);
    }
}
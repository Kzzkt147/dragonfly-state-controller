using UnityEngine;

/*
The enemy stats script is a scriptable object that holds all the data related to te stats of each enemy.
*/

[CreateAssetMenu(menuName = "Enemy/Stats")]
public class EnemyStats : ScriptableObject {
    
    public int maxHealth;
    public float walkSpeed;
    public float runSpeed;
    public float attackDelay;
}

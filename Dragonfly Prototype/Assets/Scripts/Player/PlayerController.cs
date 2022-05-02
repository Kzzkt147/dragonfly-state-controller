using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {

    [Header("Movement")]
    public float moveSpeed = 3f;
    private Vector2 movement;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    

    [Header("Attacking")]
    [SerializeField] Transform aimPivot;
    [SerializeField] GameObject meleeObject;
    [SerializeField] float attackRadius;
    [SerializeField] int weaponDamage;
    [SerializeField] float attackSpeed;
    [SerializeField] LayerMask hitLayers;
    private bool canAttack = true;
    private Vector2 aimDirection;
    private Animator meleeAnimator;
    private Vector3 mousePosition;
    
    //ABSTRACT REFERENCES
    private Camera mainCamera;

    private void Awake() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetFloat("MoveY", -1f);
        mainCamera = Camera.main;

        meleeAnimator = meleeObject.GetComponent<Animator>();

        myRigidbody.gravityScale = 0;
        myRigidbody.freezeRotation = true;
    }

    private void Update() {
        
        HandleMovement();

        HandleAttackMelee();
    }
    
    private void FixedUpdate() {
        myRigidbody.MovePosition(transform.position + (new Vector3(movement.x, movement.y, 0f)).normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void HandleMovement() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement != Vector2.zero) {
            myAnimator.SetBool("IsMoving", true);
            myAnimator.SetFloat("MoveX", movement.x);
            myAnimator.SetFloat("MoveY", movement.y);
        }
        else {
            myAnimator.SetBool("IsMoving", false);
        }
    }

    void HandleAttackMelee() {
        if(Input.GetMouseButtonDown(0) && canAttack) {
            //Get mouse position and direction relative to the player
            mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            aimDirection = mousePosition - transform.position;
            
            //Makes the player face the direction of the click
            myAnimator.SetFloat("MoveX", aimDirection.x);
            myAnimator.SetFloat("MoveY", aimDirection.y);

            //AIMING
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            aimPivot.transform.eulerAngles = new Vector3(0, 0, aimAngle);

            
            AttackMelee();
            
            
        }
    }

    public void AttackMelee() {
        meleeAnimator.SetTrigger("Attack");

        //Cast box - any enemies in the box get damaged
        RaycastHit2D hit = Physics2D.CircleCast(meleeObject.transform.position, attackRadius, aimDirection, attackRadius * 2.3f, hitLayers);

        if(hit == false) return;
        if(hit.transform.GetComponent<ITakeDamage>() != null) {
            hit.transform.GetComponent<ITakeDamage>().TakeDamage(weaponDamage);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(meleeObject.transform.position, attackRadius);
    }
}
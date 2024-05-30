using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour{
    public float velocidad;
    public float multiplicadorVelocidad;
    public float fuerzaSalto;
    public LayerMask capaSuelo;
    private Rigidbody2D rbd;
    private BoxCollider2D boxCollider;
    private Animator animator;
    void Start(){
        rbd = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        Walk();
        Jump();
        CheckForGround();
    }

    private void Walk(){
        float input = Input.GetAxis("Horizontal");
        rbd.velocity = new Vector2(input*PotenciadorVelocidad(), rbd.velocity.y);
        animator.SetBool("isWalking", true);
        if(input == 0f) {
            animator.SetBool("isWalking", false);
        } 
        Orientacion(input);
        //Debug.Log(Input.GetKeyDown(KeyCode.LeftShift));
    }
    private float PotenciadorVelocidad(){
        if(Input.GetKey(KeyCode.LeftShift)){
            animator.SetBool("isRunning", true);
            return velocidad*multiplicadorVelocidad;
        }
        animator.SetBool("isRunning", false);
        return velocidad;
    }
    private void Jump(){
        bool valido = JumpValidator();
        animator.SetFloat("jumpVelocity", rbd.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space) && valido){
            rbd.AddForce(Vector2.up*fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    private bool JumpValidator(){
        RaycastHit2D rch = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return rch.collider != null;
    }
    private void Orientacion(float input){
        if(input<0){
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        if(input>0){
            transform.localScale = new Vector2(1, transform.localScale.y);
        }   
    }
    private void CheckForGround(){
        if(JumpValidator())
            animator.SetBool("isGrounded", true);
        else
            animator.SetBool("isGrounded",false);
            
    }
}

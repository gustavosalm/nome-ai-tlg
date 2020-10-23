using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 move;
    [SerializeField]private float speed;
    private Animator anim;
    private bool canJump = true;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        move = hor * transform.right + ver * transform.forward;
        rb.velocity = move * speed * Time.deltaTime;    
        if(/*hor != 0 || */ ver > 0)
            anim.SetBool("teste", true);
        else
            anim.SetBool("teste", false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            anim.SetBool("jump", true);   
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Floor" && !canJump)
            canJump = true;
            anim.SetBool("jump", false);
    }
}

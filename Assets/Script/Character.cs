using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private ICharacterState currentState;
    [SerializeField]
    private string characterName;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public Rigidbody2D rb;
    [SerializeField]
    private Transform rotate;
    public Transform GetRotate {
        get { return rotate; }
        private set { rotate = value; }     
    }

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 7f;
    public float dirX;//
    [SerializeField]
    private Transform groundCheck;
    public bool isGrounded;//
    //public bool hasJumped;
    //public bool wasGrounded;
    //[SerializeField] LayerMask groundLayer;
    [SerializeField] Vector2 SizeCheckBox;

    public bool canAttack;
    protected float delayAttack = 0.5f;
    public float timeAtk = .5f;

    public bool isDie;
    public bool isUsing;

    public bool attackStateComplete;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rotate = gameObject.GetComponent<Transform>();
        InitState();
    }

    public void SetState(ICharacterState newState)
    {
        if (currentState != null)
            currentState.Exit(this);

        currentState = newState;
        currentState.Enter(this);
    }

    void InitState()
    {
        this.SetState(new IdleState());
    }

    private void Update()
    {
        if (!isUsing || isDie) return;
        dirX = Input.GetAxisRaw("Horizontal");
        currentState?.Update(this);
        GroundCheck();
        AttackCheck();
    }

    private void LateUpdate()
    {
        if (!isUsing) return;
        UpdatePhysic();
    }

    public void SetAnimation(string animationName)
    {
        if (animator != null)
            animator.Play(animationName);
    }

    public void UpdatePhysic()
    {
        //dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * dirX, rb.velocity.y);
        if (dirX > 0)
        {
            this.rotate.localScale = new Vector2(-1, 1);
        }
        else if (dirX < 0)
        {
            this.rotate.localScale = new Vector2(1, 1);
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //hasJumped = true;
        }
    }
    public void UpdateLogic()
    {

    }

    public void Idle()
    {
        Debug.Log(characterName + " is Idleing!");
    }

    //di chuyển
    public void Move()
    {
        Debug.Log(characterName + " is Running!");
    }

    //Nhảy
    public virtual void Jump()
    {
        Debug.Log(characterName + " is Jumpping!");
    }

    //Tấn công
    public virtual void Attack()
    {
        Debug.Log(characterName + " is Attacking!");
    }

    private void GroundCheck()
    {
        isGrounded = false;
        Vector2 sizeBox = SizeCheckBox;
        Collider2D[] coliders = Physics2D.OverlapBoxAll(groundCheck.position, sizeBox, 0f);
        if(coliders.Length > 1)
        {
            isGrounded = true;
        }
    }

    private void AttackCheck()
    {
        if(timeAtk >= 0)
        {
            timeAtk -= Time.deltaTime;
        }
        else
        {
            canAttack = true;
        }
    }

    public bool IsAnimationFinished(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f;
    }
}

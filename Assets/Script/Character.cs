using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private ICharacterState currentState;
    [SerializeField]
    public string characterName;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public Rigidbody2D rb;
    [SerializeField]
    public Transform rotate;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 7f;
    public float dirX;//
    public float dirX2;//
    [SerializeField]
    private Transform groundCheck;
    public bool isGrounded;//
    //public bool hasJumped;
    //public bool wasGrounded;
    //[SerializeField] LayerMask groundLayer;
    [SerializeField] Vector2 SizeCheckBox;

    public bool canAttack;
    [SerializeField]
    protected float delayAttack = 0.8f;
    public float timeAtk = .5f;

    public bool isDie;
    public bool isDieSkeletonFish;
    public bool isUsing;

    public bool attackStateComplete;

    public bool isUnderWater;

    public float holdBtnTime = 0f;
    public bool isPressbtnJump;
    public bool isHoldBtn;

    public bool isControlWithUI;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rotate = gameObject.GetComponent<Transform>();
        InitState();

        //EventManager.Instance.LeftObject += MoveLeft;
        //EventManager.Instance.RightObject += MoveRight;
        //EventManager.Instance.Stopp += StopMove;
        //EventManager.Instance.JumpObject += Jumpp;
        //EventManager.Instance.DropObj += Dropp;
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
        canAttack = true;
    }

    private void Update()
    {
        //dirX = Input.GetAxisRaw("Horizontal");
        //currentState?.Update(this);
        if (isUsing && !isDie)
        {
            currentState?.Update(this);
            GroundCheck();
            AttackCheck();
        }
        if (isDie)
        {
            currentState?.Update2(this);
        }
    }

    private void FixedUpdate()
    {
        if (!isUsing || isDie) return;
        if (isPressbtnJump)
        {
            holdBtnTime += Time.fixedDeltaTime;
            if(isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            if (holdBtnTime >= 0.15f)
            {
                isHoldBtn = true;
            }
            else if (holdBtnTime < 0.15f)
            {
                isHoldBtn = false;
            }
        }
        SmoothJump();
    }

    private void LateUpdate()
    {
        if (!isUsing || isDie) return;
        UpdatePhysic();
    }

    public void SetAnimation(string animationName)
    {
        if (animator != null)
            animator.Play(animationName);
    }

    public void UpdatePhysic()
    {
        if(!isControlWithUI)
            dirX = Input.GetAxisRaw("Horizontal");
        
        Flip();
        rb.velocity = new Vector2(speed * dirX, rb.velocity.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //hasJumped = true;
        }
    }

    void Flip()
    {
        if (dirX > 0)
        {
            this.rotate.localScale = new Vector2(-1, 1);
        }
        else if (dirX < 0)
        {
            this.rotate.localScale = new Vector2(1, 1);
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

    //private void MoveRight()
    //{
    //    if (!isUsing) return;
    //    dirX = 1;
    //    this.rotate.localScale = new Vector2(-1, 1);
    //    Debug.Log(characterName + " ffff!");
    //}
    //private void MoveLeft()
    //{
    //    if (!isUsing) return;
    //    dirX = -1;
    //    this.rotate.localScale = new Vector2(1, 1);
    //    Debug.Log(characterName + " ffff");
    //}
    //private void StopMove()
    //{
    //    dirX = 0;
    //    rb.velocity = new Vector2(0, rb.velocity.y);
    //}
    //private void Jumpp()
    //{
    //    if (!isUsing) return;
    //    if (isGrounded)
    //    {
    //        //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //        isPressbtnJump = true;
    //        holdBtnTime = 0;
    //        //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //    }
    //}
    //private void Dropp()
    //{
    //    if (!isUsing) return;
    //    isPressbtnJump = false;
    //}

    void SmoothJump()
    {
        if (isGrounded)
        {
            holdBtnTime = 0;
            return;
        }
        if (rb.velocity.y < 0)
        {
            //tang dan van toc roi xuong
            rb.velocity += Vector2.up * Physics2D.gravity.y * (9f - 1f) * Time.deltaTime;
        }
        else if (rb.velocity.y >= 0 && !isHoldBtn)
        {
            //tang dan van toc nhay len khi ko giu nut nhay
            rb.velocity += Vector2.up * Physics2D.gravity.y * (3.5f - 1f) * Time.deltaTime;
        }
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
        if (timeAtk >= 0)
        {
            timeAtk -= Time.deltaTime;
        }
        else
        {
            canAttack = true;
        }
    }

    //IEnumerator WaitAttack()
    //{
    //    canAttack = false;
    //    yield return new WaitForSeconds(delayAttack);
    //    canAttack = true;
    //}
    //public void WatingAttack()
    //{
    //    StartCoroutine(WaitAttack());
    //}

    public bool IsAnimationFinished(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") && isDieSkeletonFish)
    //    {
    //        Debug.Log("cham tuong");
    //        this.rb.velocity = Vector2.zero;
    //        this.rb.isKinematic = true;
    //        //this.rb.bodyType = RigidbodyType2D.Static;
    //    }

    //    if(collision.gameObject.CompareTag("Player") && isDie)
    //    {
    //        isDieSkeletonFish = false;
    //        rb.gravityScale = 7f;
    //    }
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") && isDieSkeletonFish)
    //    {
    //        Debug.Log("cham tuong");
    //        this.rb.velocity = new Vector2(0, rb.velocity.y);
    //        this.rb.isKinematic = false;
    //        this.rb.bodyType = RigidbodyType2D.Static;
    //    }
    //}
}

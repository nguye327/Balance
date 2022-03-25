using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //public variables
    //movement
    public Transform groundCheck;
    public Transform head;
    public Transform knees;
    //combat
    public Transform attacks;
    public Transform sAttack;
    public Transform lAttack;
    public Transform aoeAttack;

    //private variables
    
    [SerializeField] private bool grounded;
    private bool startJump;
    private bool stoppedJump;
    [SerializeField] private bool wallGrab;
    [SerializeField] private bool dashing;
    private bool pushing;
    private bool canAttack;
    private bool isAttacking;
    private bool takingDamage;
    private bool usingDark;
    private bool upHeld;
    private bool downHeld;

    private float coyote;
    private float marioTime;
    private float sideJTime;
    private float horzM;

    private Rigidbody2D rb2d;
    private Animator anim;
    private LayerMask groundLayer;
    private InputAction moveInput;

    private int currHP;

    //constants
    private const float JUMP_SPD = 6.4f;
    private const float MARIO_MAX = 0.18f;
    private const float SPEED = 5f;
    private const float DASH = 2.5f;
    private const float COYO_MAX = 0.35f;
    private const float VERT_COLL_DIST = 0.24f;
    private const float HORIZ_COLL_DIST = 0.27f;
    private const float SMALL_ATTACK_RAD = 0.5f;
    private const float LARGE_ATTACK_RAD = 1f;
    private const float AOE_ATTACK_RAD = 1.5f;
    private const int MAX_HP_BASE = 100;

    private AttStackScript attStack;

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();

        attStack = new AttStackScript();
        startJump = false;
        dashing = false;
        stoppedJump = true;
        grounded = false;
        wallGrab = false;
        groundLayer = LayerMask.GetMask("Ground");
        sideJTime = 0f;
        canAttack = true;
        isAttacking = false;
        takingDamage = false;
        usingDark = false;

        currHP = (PlayerPrefs.HasKey("currHP")) ? PlayerPrefs.GetInt("currHP") : MAX_HP_BASE;
    }

    //new input listeners
    void OnHorizontal(InputValue value)
    {
        if (sideJTime <= 0f)
            horzM = value.Get<float>();

    }
    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            if ((grounded || coyote < COYO_MAX))
            {
                coyote = COYO_MAX;
                startJump = true;
                stoppedJump = false;
                marioTime = 0f;
            }
            else if (wallGrab)
            {
                rb2d.velocity = new Vector2(-horzM * SPEED * 5, JUMP_SPD * 1.25f);
                wallGrab = false;
                sideJTime = 0.2f;
            }
        }
        else if (!stoppedJump)
        {
            stoppedJump = true;
        }
    }
    void OnDash(InputValue value)
    {
        if (value.isPressed && grounded)
        {
            dashing = true;
            Debug.Log("dashing");
        }
        else if (!value.isPressed)
        {
            dashing = false;
        }
    }

    void OnSwap(InputValue value)
    {
        usingDark = (usingDark) ? false : true;
        //remove, replace with animation + ui change
        string say = (usingDark) ? "Switching to dark" : "Switching to light";
        Debug.Log(say);
    }

    void OnPhysical(InputValue value)
    {
        attStack.stored[(int)(AttStackScript.Inputs.PAttack)] = true;
        if (rb2d.velocity.magnitude > 0f)
            attStack.stored[(int)(AttStackScript.Inputs.Forward)] = true;
        if (upHeld)
            attStack.stored[(int)(AttStackScript.Inputs.Up)] = true;
        else if (downHeld)
            attStack.stored[(int)(AttStackScript.Inputs.Down)] = true;
    }
    void OnMagical(InputValue value)
    {
        attStack.stored[(int)(AttStackScript.Inputs.MAttack)] = true;
        if (rb2d.velocity.magnitude > 0f)
            attStack.stored[(int)(AttStackScript.Inputs.Forward)] = true;
        if (upHeld)
            attStack.stored[(int)(AttStackScript.Inputs.Up)] = true;
        else if (downHeld)
            attStack.stored[(int)(AttStackScript.Inputs.Down)] = true;
    }
    void OnUp(InputValue value)
    {
        if (value.isPressed)
            upHeld = true;
        else
            upHeld = false;

    }
    void OnDown(InputValue value)
    {
        if (value.isPressed)
            downHeld = true;
        else
            downHeld = false;
        
    }


    private void Update()
    {
        if (currHP <= 0)
        {
            //game over
        }

        string result = attStack.Update(Time.deltaTime);       
        //check for combat execution
        if (result != "waiting")
        {
            attStack.Reset();
            if (canAttack)
            {
                switch (result)
                {
                    //counter
                    case "counter":
                        Debug.Log(result);
                        break;
                    //combo
                    case "combo":
                        Debug.Log(result);
                        break;
                    //combo forward
                    case "forward combo":
                        Debug.Log(result);
                        break;

                    //physical attack
                    case "phys":
                        Debug.Log(result);
                        break;
                    //physical forward
                    case "phys forward":
                        Debug.Log(result);
                        break;
                    //physical down
                    case "phys down":
                        Debug.Log(result);
                        break;
                    //physical up
                    case "phys up":
                        Debug.Log(result);
                        break;

                    //magic attack
                    case "mag":
                        Debug.Log(result);
                        break;
                    //magic forward
                    case "mag forward":
                        Debug.Log(result);
                        break;
                    //magic down
                    case "mag down":
                        Debug.Log(result);
                        break;
                    //magic up
                    case "mag up":
                        Debug.Log(result);
                        break;
                }
            }
            

        }
        //if the player is not in an attack or damage animation, can make a new attack
        if (!isAttacking && !takingDamage)
        {
            canAttack = true;
        }
    }
    void FixedUpdate()
    {
        Movement();
        Combat();
    }

    private void Movement()
    {
        float d = (dashing) ? DASH : 0f;
        //horizontal
        if (sideJTime <= 0f)
            rb2d.velocity = new Vector2(horzM * (SPEED + d), rb2d.velocity.y);
        else
            sideJTime -= Time.deltaTime;
        //force object to not drill horizontally
        //raycast for terrain
        Debug.DrawRay(head.position, transform.right * horzM, Color.red);
        RaycastHit2D hitH = Physics2D.Raycast(head.position, transform.right * horzM, HORIZ_COLL_DIST,groundLayer.value);
        RaycastHit2D hitK = Physics2D.Raycast(knees.position, transform.right * horzM, HORIZ_COLL_DIST, groundLayer.value);
        if (hitH)
        {
            wallGrab = true;
            //on hit, if distance is under the const, force the object to a specific spot
            Debug.Log("Hit: " + hitH.distance);
            if (hitH.distance < HORIZ_COLL_DIST)
            {
                rb2d.velocity = new Vector2(-horzM * (HORIZ_COLL_DIST - hitH.distance), rb2d.velocity.y);
            }

        }
        else if (hitK)
        {
            wallGrab = true;
            //on hit, if distance is under the const, force the object to a specific spot
            Debug.Log("Hit: " + hitK.distance);
            if (hitH.distance < HORIZ_COLL_DIST)
            {
                rb2d.velocity = new Vector2(-horzM * (HORIZ_COLL_DIST - hitK.distance), rb2d.velocity.y);
            }

        }
        else
            wallGrab = false;
        
            
        //vertical
        //check for floor
        grounded = Physics2D.OverlapCircle(groundCheck.position, VERT_COLL_DIST, groundLayer);
        //update coyote timer, can't wallgrab when on the ground
        if (grounded)
        {
            coyote = 0f;
            wallGrab = false;
        }
            
        else
        {
            coyote += Time.deltaTime;
            dashing = false;
        }
            
        //jump/"mario" jump
        if (startJump || !stoppedJump)
        {
            startJump = false;
            rb2d.velocity = new Vector2(rb2d.velocity.x, JUMP_SPD);
            //update "mario" jump time
            marioTime += Time.deltaTime;
            if (marioTime > MARIO_MAX)
                stoppedJump = true;
        }

        //facing stuff
        if (rb2d.velocity.x > 0f)
        {
            //facing right
            attacks.transform.position = new Vector2(transform.position.x + 0.75f, attacks.transform.position.y);
            aoeAttack.transform.position = new Vector2(transform.position.x, aoeAttack.transform.position.y);
        }
        else if (rb2d.velocity.x < 0f)
        {
            //facing left
            attacks.position = new Vector2(transform.position.x - 0.75f, attacks.transform.position.y);
            aoeAttack.position = new Vector2(transform.position.x, aoeAttack.transform.position.y);
        }
    }

    private void Combat()
    {
        
    }

    private void OnDrawGizmos()
    {
        //debugging gizmos; remove from final build?
        Gizmos.DrawSphere(groundCheck.position, VERT_COLL_DIST);
        Gizmos.DrawLine(head.position, head.position + (transform.right * HORIZ_COLL_DIST));
        Gizmos.DrawWireSphere(sAttack.position, SMALL_ATTACK_RAD);
        Gizmos.DrawWireSphere(lAttack.position, LARGE_ATTACK_RAD);
        Gizmos.DrawWireSphere(aoeAttack.position, AOE_ATTACK_RAD);
        
    }

    IEnumerator AttackAnimTimer(float waitTime)
    {
        isAttacking = true;
        canAttack = false;
        //yield on a new YieldInstruction that waits for waitTime seconds.
        yield return new WaitForSeconds(waitTime);
        //is no longer attacking/in the attack animation
        isAttacking = false;
    }
}

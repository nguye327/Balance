using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding")]
    public float aggroRange = 10f;
    public float speed = 400f;
    public float jump = 0.3f;
    public float jumpOffset = 0.1f;
    public float jumpNodeReq = 0.8f;
    public float nextWaypointCheck = 1f;

    private float[] damageMult = new float[3];
    [Header("Combat")]
    [SerializeField]private float hp;
    private float deathAnimTime;
    private float pathRefreshTime;

    private bool flying;
    private bool grounded;
    private bool chaser;
    private bool hasFacing;
    private int currentWaypoint;

    private bool dying;
    [SerializeField] private bool attacking;
    [SerializeField] private bool counterable;
    [SerializeField] private bool flinching;
    private float flinchCheck;
    private float flinchThreshold;
    private float flinchTime;

    private Transform player;
    private Transform startPos;
    private Transform target;
    private Animator anim;
    private LayerMask playerLayer;
    private Path path;
    private Seeker seeker;
    private Rigidbody2D rb2d;
    private Attack[] attacks;

    private const float VERT_COLL_DIST = 0.34f;
    class Attack
    {
        public float windUp;
        public Transform attackPos;
        public float rad;
        public int attackType;
        public float damage;
        public bool counterable;

        public Attack(float wu, Transform ap, float r, int at, float d, bool c)
        {
            windUp = wu;
            attackPos = ap;
            rad = r;
            attackType = at;
            damage = d;
            counterable = c;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dying = false;
        attacking = false;
        flinching = false;
        player = GameObject.Find("player").GetComponent<Transform>();
        startPos = transform;
        target = player;
        anim = GetComponent<Animator>();
        playerLayer = LayerMask.GetMask("Player");
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();
        pathRefreshTime = 0.25f;

        currentWaypoint = 0;

        startPos = transform;

        flinchCheck = 0f;
        flinchTime = 0f;

        InvokeRepeating("UpdatePath", 0f, pathRefreshTime);
        InvokeRepeating("UpdateIdlePos", 0f, 3f);

        EnemySpecificStart();
    }
    private void EnemySpecificStart()
    {
        flying = false;
        grounded = false;
        chaser = true;
        hasFacing = true;

        hp = 100f;
        flinchThreshold = hp / 2;

        attacks = new Attack[] {new Attack(1f, transform, 1.5f, 0, 5f, true),
                                new Attack(2f, transform, 1.5f, 0, 20f, false)};
        damageMult = new float[] { 1f, 1f, 1f };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp <= 0f && !dying)
            Die();
        else if (!flinching)
        {
            //isangry checks aggro distance, chaser is false if the enemy is turret type
            if (IsAngry() && chaser)
            {
                target = player;
                float dist = Vector2.Distance(rb2d.position, target.position);
                if (dist < nextWaypointCheck && (grounded || flying) && !attacking)
                    Combat();
                else if (!attacking)
                    Pathfinding();
            }
            else if (IsAngry() && !chaser)
            {

            }
            else
            {
                target = startPos;
                PathfindingIdle();
            }
        }
        else
        {
            if (flinchTime < 0.5f)
                flinchTime += Time.deltaTime;
            else
            {
                flinchTime = 0f;
                flinching = false;
            }
        }
    }

    private void Combat()
    {
        //if close enough to the player, attack
        float dist = Vector2.Distance(rb2d.position, target.position);
        if (dist < 1.5f)
        {
            attacking = true;
            //pick a random attack
            System.Random random = new System.Random();
            int num = random.Next(0, attacks.Length);
            //start timer to make the attack
            StartCoroutine(AttackDamageTimer(attacks[num]));
            //play the animation
        }


    }
    private void UpdatePath()
    {
        if (IsAngry() && seeker.IsDone())
        {
            seeker.StartPath(rb2d.position, target.position, OnPathComplete);
        }
    }
    private void Pathfinding()
    {
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
            return;
        Vector2 feetPos = transform.position;
        feetPos.y -= VERT_COLL_DIST;
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        grounded = Physics2D.OverlapCircle(feetPos, VERT_COLL_DIST, groundLayer);
            //Physics2D.Raycast(transform.position, -Vector2.up, GetComponent<Collider2D>().bounds.extents.y + jumpOffset);
        Vector2 dir = ((Vector2)path.vectorPath[currentWaypoint] - rb2d.position).normalized;
        Vector2 force = new Vector2(dir.x * speed * Time.deltaTime, 0f);

        //jump if grounded, not a flying enemy, and needs to jump to reach target
        if (!flying && grounded)
        {
            if (dir.y > jumpNodeReq)
                rb2d.AddForce(Vector2.up * speed * jump);
        }

        rb2d.AddForce(force);
        float dist = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointCheck)
            currentWaypoint++;

        if (hasFacing)
        {
            if (rb2d.velocity.x > 0.05f)
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else if (rb2d.velocity.x < -0.05f)
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    
    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;    
        }
    }
    private void UpdateIdlePos()
    {

    }
    private void PathfindingIdle()
    {
        //do pathfinding when idle
    }
    private bool IsAngry()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        return (distance < aggroRange) ? true : false;
    }
    public void TakeDamage(float damage, int type)
    {
        hp -= damage * damageMult[type];
        flinchCheck += damage * damageMult[type];
        if (flinchCheck >= flinchThreshold)
        {
            flinchCheck = 0f;
            flinching = true;
        }
    }
    public void Countered()
    {
        flinching = true;
    }
    private void Die()
    {
        dying = true;
        //play death animation
        //anim.Play("death");
        //destroy game object
        StopAllCoroutines();
        StartCoroutine(DeleteMe());
    }

    IEnumerator DeleteMe()
    {
        yield return new WaitForSeconds(deathAnimTime);
        Destroy(this.gameObject);
    }
    IEnumerator AttackDamageTimer(Attack attack)
    {
        //Gizmos.DrawWireSphere(attack.attackPos.position, attack.rad);
        Debug.Log("attack");
        //windUp is the amount of time between the start of the animation and when it should deal damage
        yield return new WaitForSeconds(attack.windUp);
        attacking = false;
        //deal damage to player in the radius
        Vector2 actualPos = transform.position;

        Collider2D[] hits = Physics2D.OverlapCircleAll(attack.attackPos.position, attack.rad, playerLayer);
        foreach (Collider2D hit in hits)
        {
            hit.gameObject.GetComponent<PlayerController>().TakeDamage(attack.damage, attack.attackType, transform.position);
        }
    }
}

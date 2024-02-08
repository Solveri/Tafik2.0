using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAI : MonoBehaviour
{
    public float speed = 200f;
    public float disToWaypoint = 3f;
    public Transform target;

    Seeker seeker;
    Path path;
    Rigidbody2D rb;
    [SerializeField] States state;
    private int currentWayPoint = 0;
    private bool hasReachedEnd = false;
    public bool hasReachedTarget { get { return hasReachedEnd; } }

    [SerializeField] public Vector2 dir;
    [SerializeField] float dis;
    public enum States
    {
        idle,
        Chase,
        Attack,
        RangedAttack
    }
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);

    }
    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.transform.position, target.transform.position, onPathComplate);
        }

    }
    /*we need to check the distance between the player and enemy at all time
     * if player is too far from enemy do nothing(idleState)
     * if player is at a good distance from enemy then enemy starts chasing the player(ChaseState)
     * if enemy is at attack range than attack(attackState)
     */
    void onPathComplate(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        ChangeStates();
        if (path == null)
        {
            return;
        }
        if (currentWayPoint >= path.vectorPath.Count)
        {
            hasReachedEnd = true;
            return;
        }
        else
        {
            hasReachedEnd = false;
        }
        dir = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        dis = Vector2.Distance(this.transform.position, (Vector2)target.transform.position);
        if (state == States.idle)
        {
            return;
        }
        else if (state == States.Chase)
        {
            Vector2 force = dir * speed * Time.deltaTime;
            rb.AddForce(force);
            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

            if (distance < disToWaypoint)
            {
                currentWayPoint++;
            }
        }


    }
    private void ChangeStates()
    {
        if (dis > 10)
        {
            state = States.idle;

        }
        else if (dis < 10 && !hasReachedEnd)
        {
            state = States.Chase;
        }
        else if (hasReachedEnd)
        {
            state = States.Attack;
        }
    }
}

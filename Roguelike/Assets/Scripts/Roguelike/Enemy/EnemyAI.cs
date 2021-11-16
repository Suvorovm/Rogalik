using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI: MonoBehaviour
{
    public Transform target;
    public float speed=15f;
    public float nextWaypointD = 2f;
    Path path;
    int currentWaypoint=0;
    private bool reachedEndofPath=false;
    Seeker seeker;
    Rigidbody2D rb;
    float attackDistance=1.5f;
    private float attackTimer;
    float cooldown=2.5f;
    public float visible = 10f;
    public float enemyDamage = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath",0f,.5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone()) seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p) {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndofPath =true;
            return;
        }
        else
        {
            reachedEndofPath = false;
        }
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        if (attackTimer > 0) {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer <= 0) {
            attackTimer = 0;
        }
        if (distanceToTarget < visible && distanceToTarget>attackDistance)
        {
            
            Walk();
            
        }

        if (distanceToTarget < visible && distanceToTarget <= attackDistance && attackTimer==0)
        {
            Attack();
            attackTimer = cooldown;
        }

        if (distanceToTarget > visible)
        {
            Stand();
        }
        
        
    }

    void Walk()
    {
       Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;
               Vector2 force = direction * speed * Time.deltaTime;
               rb.AddForce(force);
               float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
               if (distance < nextWaypointD)
               {
                   currentWaypoint++;
               } 
    }

    void Attack()
    {
        Debug.Log("Attack"); 
    }

    void Stand()
    {
        
    }
}

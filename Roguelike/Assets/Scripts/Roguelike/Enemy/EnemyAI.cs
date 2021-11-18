using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using Pathfinding;
using Roguelike.World.Service;

public class EnemyAI: MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed=15f;
    private float nextWaypointD = 2f;
    private Path path;
    private int currentWaypoint=0;
    private bool reachedEndofPath=false;
    private Seeker seeker;
    private Rigidbody2D rb;
    [SerializeField]private float attackDistance=1.5f;
    private const float UPDATE_TIME=0.5f;
    private float next_Update_Time = 0.0f;
    private float attackTimer;
    [SerializeField]private float cooldown=2.5f;
    [SerializeField]private float visible = 10f;
    [SerializeField]private float enemyDamage = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void UpdatePath()
    {
        if (IsUpdateTimeReached()==true)
        {
            if(seeker.IsDone()) seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        else
        {
            return;
        }
        
    }
    private  void OnPathComplete(Path p) {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }  
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdatePath();
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
        AttackTimer();
        if (distanceToTarget < visible && distanceToTarget>attackDistance)
        {
            
            Walk();
            
        }

        if (distanceToTarget < visible && distanceToTarget <= attackDistance && attackTimer==0)
        {
            Attack();
            attackTimer = cooldown;
        }
    }
    private void Walk()
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

    private void Attack()
    {
        HealthService healthService = GameApplication.RequireService<HealthService>();
        healthService.DecreaseHealth(enemyDamage);
        Debug.Log("Attack"); 
    }

    public bool IsUpdateTimeReached()
    {
        if (Time.time > next_Update_Time)
        {
            next_Update_Time += UPDATE_TIME;
            return true;
        }
        else
        {
            return false;
        }
    }
    private void AttackTimer()
    {
        if (attackTimer > 0) {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer <= 0) {
            attackTimer = 0;
        }
    }
}

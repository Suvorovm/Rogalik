using Roguelike.World.Service;
using Core;
using UnityEngine;
using Pathfinding;
public class EnemyAI: MonoBehaviour
{
    [SerializeField]private float _cooldown=2.5f;
    [SerializeField]private float _visible = 10f;
    [SerializeField]private float _enemyDamage = 10; 
    [SerializeField]private float _speed = 15f;
    [SerializeField]private float _attackDistance=1.5f;
    private float _nextWaypointD = 2f;
    private Path path;
    private int _currentWaypoint=0;
    private bool _reachedEndofPath=false;
    private Seeker _seeker;
    private Rigidbody2D _rb;
    private Transform _target;
    private const float _UPDATE_TIME=0.5f;
    private float _next_Update_Time = 0.0f;
    private float _attackTimer;
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void UpdatePath()
    {
        if (IsUpdateTimeReached()==true)
        {
            if(_seeker.IsDone()) _seeker.StartPath(_rb.position, _target.position, OnPathComplete);
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
            _currentWaypoint = 0;
        }  
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdatePath();
        if (path == null) {
            return;
        }
        if (_currentWaypoint >= path.vectorPath.Count)
        {
            _reachedEndofPath =true;
            return;
        }
        else
        {
            _reachedEndofPath = false;
        }
        float distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);
        AttackTimer();
        if (distanceToTarget < _visible && distanceToTarget>_attackDistance)
        {
            
            Walk();
            
        }

        if (distanceToTarget < _visible && distanceToTarget <= _attackDistance && _attackTimer==0)
        {
            Attack();
            _attackTimer = _cooldown;
        }
    }
    private void Walk()
    {
       Vector2 direction = ((Vector2) path.vectorPath[_currentWaypoint] - _rb.position).normalized;
               Vector2 force = direction * _speed * Time.deltaTime;
               _rb.AddForce(force);
               float distance = Vector2.Distance(_rb.position, path.vectorPath[_currentWaypoint]);
               if (distance < _nextWaypointD)
               {
                   _currentWaypoint++;
               } 
    }

    private void Attack()
    {
        HealthService healthService = GameApplication.RequireService<HealthService>();
        healthService.DecreaseHealth(_enemyDamage);
        Debug.Log("Attack"); 
    }

    public bool IsUpdateTimeReached()
    {
        if (Time.time > _next_Update_Time)
        {
            _next_Update_Time += _UPDATE_TIME;
            return true;
        }
        else
        {
            return false;
        }
    }
    private void AttackTimer()
    {
        if (_attackTimer > 0) {
            _attackTimer -= Time.deltaTime;
        }
        if (_attackTimer <= 0) {
            _attackTimer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public Transform patrolPoint1;
    public Transform patrolPoint2;
    public float patrolSpeed = 2.0f;
    public float patrolArrivalDistance = 0.1f;
    
    private Transform currentPatrolTarget;
    private Vector3 originalScale;
    
    

    private Vector2 walkDirection;

    private float changeDirectionTime;
    private float _currentChangeTime;

    private Animator enemyAI;

    void Start()
    {
        enemyAI = GetComponent<Animator>();
        currentPatrolTarget = patrolPoint1;
        originalScale = transform.localScale;
    }

    void Update()
    {
        MoveDirection();
        CountTime();
        
        if (Vector2.Distance(transform.position, currentPatrolTarget.position) <= patrolArrivalDistance)
        {
            // Troque o ponto de patrulha para o próximo
            if (currentPatrolTarget == patrolPoint1)
            {
                currentPatrolTarget = patrolPoint2;
                transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
            }
            else
            {
                currentPatrolTarget = patrolPoint1;
                transform.localScale = originalScale;
            }
        }
        
        MoveTowardsTarget(currentPatrolTarget);
    }
    
    void MoveTowardsTarget(Transform target)
    {
        // Movimente o inimigo em direção ao ponto de patrulha com a velocidade de patrulha
        float step = patrolSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    public void SetWalkDirection(Vector2 direction) { //função pra mudar a direção

        walkDirection = direction;
    }

    public void MoveDirection() {
        transform.Translate(walkDirection * Time.deltaTime);
    }

    public void CountTime() {
        if(_currentChangeTime <= changeDirectionTime) {
            _currentChangeTime += Time.deltaTime;
        }
        else {
            _currentChangeTime = 0;
            //enemyAI.SetTrigger("ChangeDirection");
        }
    }
}

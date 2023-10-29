using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Vector2 walkDirection;

    private float changeDirectionTime;
    private float _currentChangeTime;

    private Animator enemyAI;

    void Start()
    {
        enemyAI = GetComponent<Animator>();
    }

    void Update()
    {
        MoveDirection();
        CountTime();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject dieEfect;
    [SerializeField] float turnSpeed = 5f;  
    Transform target;
    int scorePerHit = 1;
    Score score;
    EnemySpoon enemySpoon;
 
    void Start()
    {       
        enemySpoon = FindObjectOfType<EnemySpoon>();
        target = FindObjectOfType<PlayerLogic>().transform;
        score = FindObjectOfType<Score>();
    }

    void Update()
    {
        FaceToTarget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fire")
        {           
            DieInst();
            enemySpoon.countEnemy--;
            score.scoreHit(scorePerHit);
            Destroy(collision.gameObject);
        }
    }
    public void DieInst()
    {
        Instantiate(dieEfect, transform.position, transform.rotation);      
        Destroy(gameObject);
    }
    private void FaceToTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion LookRotarion = Quaternion.LookRotation(Vector3.forward, direction);
        Quaternion posZ = transform.rotation;    
        transform.rotation = Quaternion.Slerp(posZ,LookRotarion,turnSpeed *Time.deltaTime);
    }   
}

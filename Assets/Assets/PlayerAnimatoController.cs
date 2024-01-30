using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerAnimatoController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    public GameObject Bullet;
    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, .1f, Time.deltaTime);
        
    }

    public void Attack(){
        animator.SetTrigger("attack");
        if(gameObject.tag == "Melee"){
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
            foreach(Collider enemy in hitEnemies){
                PlayerHealth ph = enemy.GetComponent<PlayerHealth>();
                if (ph != null)
                {
                    ph.Destroy();
                }
            }
        }
        if(gameObject.tag == "Range"){
            GameObject peluru = Instantiate(Bullet, attackPoint.transform.position, attackPoint.transform.rotation);
            //Instantiate(throwEffect, Player.transform.position, transform.rotation);
            Rigidbody rb = peluru.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * attackRange, ForceMode.VelocityChange);
        }
        
    }

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}

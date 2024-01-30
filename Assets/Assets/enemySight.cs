using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class enemySight : MonoBehaviour
{
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public PlayerAnimatoController animate;

    public enum State
    {
        PATROL,
        CHASE
    }

    public State state;
    private bool alive;

    public Light view;

    public GameObject[] waypoint;
    private int waypointInd = 0;
    public float patrolSpeed = 0.5f;

    public GameObject target;
    public float chaseSpeed = 1f;

    public float heightMultiplier;
    public float sightDist = 3;

    public float followTime = 10;
    private float timer = 0;
    
    public float attackRate = 2f;
    float nextTimeAttack = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();

        agent.updatePosition = true;
        agent.updateRotation = false;

        state = enemySight.State.PATROL;
        alive = true;

        heightMultiplier = .8f;
        //Debug.Log(waypoint.Length);
        StartCoroutine("FSM");
    }

    IEnumerator FSM(){
        while(alive){
            switch(state){
                case State.PATROL:
                    Patrol();
                    break;
                case State.CHASE:
                    Chase();
                    break;
            }
            yield return null;
        }
    }

    void Patrol(){
        view.color = Color.green;
        agent.speed = patrolSpeed;
        if(Vector3.Distance(this.transform.position, waypoint[waypointInd].transform.position) >= 2){
            agent.SetDestination(waypoint[waypointInd].transform.position);
            character.Move(agent.desiredVelocity, false, false);
        }
        else if(Vector3.Distance(this.transform.position, waypoint[waypointInd].transform.position) <= 2){
            //Debug.Log(waypointInd);
            waypointInd += 1;
            if(waypointInd == waypoint.Length){
                waypointInd = 0;
            }
        }
        else{
            character.Move(Vector3.zero, false, false);
        }
    }

    void Chase(){
        view.color = Color.red;
        timer += Time.deltaTime;
        agent.speed = chaseSpeed;
        agent.SetDestination(target.transform.position);
        character.Move(agent.desiredVelocity, false, false);
        if((timer >= followTime) && (Vector3.Distance(this.transform.position, target.transform.position) >= 2)){
            state = enemySight.State.PATROL;
            timer = 0;
        }
    }

    void Update(){
        if(state == enemySight.State.CHASE){
            if(Time.time >= nextTimeAttack){
                animate.Attack();
                //Debug.Log("Punch");
                nextTimeAttack = Time.time + attackRate;
            }
        }
    }

    void FixedUpdate(){
        RaycastHit hit;
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist, Color.green);
        if(Physics.Raycast(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, out hit, sightDist)){
            if(hit.collider.gameObject.tag == "Player"){
                state = enemySight.State.CHASE;
                target = hit.collider.gameObject;
            }
        }
        if(Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized * sightDist, out hit, sightDist)){
            if(hit.collider.gameObject.tag == "Player"){
                state = enemySight.State.CHASE;
                target = hit.collider.gameObject;
            }
        }
        if(Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist, out hit, sightDist)){
            if(hit.collider.gameObject.tag == "Player"){
                state = enemySight.State.CHASE;
                target = hit.collider.gameObject;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class basicAI : MonoBehaviour
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

    public float attackRate = 2f;
    float nextTimeAttack = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();

        agent.updatePosition = true;
        agent.updateRotation = false;

        state = basicAI.State.PATROL;
        alive = true;
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
        agent.speed = chaseSpeed;
        agent.SetDestination(target.transform.position);
        character.Move(agent.desiredVelocity, false, false);
        if(Vector3.Distance(this.transform.position, target.transform.position) <= 2){
            //animate.Attack();
        }
    }

    void Update(){
        if(state == basicAI.State.CHASE){
            if(Time.time >= nextTimeAttack){
                animate.Attack();
                Debug.Log("Punch");
                nextTimeAttack = Time.time + attackRate;
            }
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            state = basicAI.State.CHASE;
            target = collider.gameObject;
            //this.transform.LookAt(target.transform,Vector3.up);
        }
    }

    void OnTriggerExit(Collider collider){
        if(collider.tag == "Player"){
            state = basicAI.State.PATROL;
        }
    }
}

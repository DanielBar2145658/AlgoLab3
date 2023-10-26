using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class NavMesh : MonoBehaviour
{
    public GameObject Target;
    NavMeshAgent agent;
    bool isWalking = true;
    Animator animator;


    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = speed;
        animator.speed = speed / 1.7f; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            agent.destination = Target.transform.position;
            animator.SetBool("IsWalking", true);
        }
        else 
        {
            agent.destination = transform.position;
            animator.SetBool("IsWalking", false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name =="Enemy") 
        {
            animator.speed = 1.3f;
            animator.SetBool("Attack", true);

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Enemy")
        {
            isWalking = true;
            animator.SetBool("IsWalking", true);
        }

    }

}

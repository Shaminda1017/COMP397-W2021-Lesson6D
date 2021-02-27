using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum CryptoState
{
    IDLE,
    RUN,
    JUMP
}

public class CryptoBehaviour : MonoBehaviour
{
    [Header("Line of sight")]
    public LayerMask collisionLayer;
    public Vector3 LOSoffset = new Vector3(0.0f, 2.0f, -5.0f);
    public bool HasLOS;
    public Vector3 playerLocation;


    private NavMeshAgent agent;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HasLOS)
        {
            agent.SetDestination(playerLocation);
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetInteger("AnimState", (int)CryptoState.IDLE);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetInteger("AnimState", (int)CryptoState.RUN);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetInteger("AnimState", (int)CryptoState.JUMP);
        }        
    }

    void OnTriggerEnterEenter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HasLOS = true;
            playerLocation = other.transform.position;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HasLOS = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerLocation = other.transform.position;
        }
    }
}
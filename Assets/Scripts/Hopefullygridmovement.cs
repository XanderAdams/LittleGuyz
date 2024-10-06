using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Hopefullygridmovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 oriPos, targetPos;
    private float timeToMove = 0.2f;

    public GameObject panel;
    public Animator animator;

    public bool canMove = true;



    // Update is called once per frame
    void Update()
    {
        if(panel.activeInHierarchy == true)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
        if(canMove == true){
        
            if (Input.GetKey(KeyCode.W) && !isMoving)
            { StartCoroutine(MovePlayer(Vector3.up)); 
              animator.SetInteger("Facing",3);}
            if (Input.GetKey(KeyCode.A) && !isMoving)
            { StartCoroutine(MovePlayer(Vector3.left)); 
            animator.SetInteger("Facing",1);}
            if (Input.GetKey(KeyCode.S) && !isMoving)
            { StartCoroutine(MovePlayer(Vector3.down)); 
            animator.SetInteger("Facing",0);}
            if (Input.GetKey(KeyCode.D) && !isMoving)
            { StartCoroutine(MovePlayer(Vector3.right)); 
            animator.SetInteger("Facing",2);}
        }
    }

    void Start()
    {
        animator=gameObject.GetComponent<Animator>();
    }
    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedtime = 0;
        oriPos = transform.position;
        targetPos = oriPos + direction;

        while(elapsedtime< timeToMove)
        {
            transform.position = Vector3.Lerp(oriPos, targetPos, (elapsedtime / timeToMove));
            elapsedtime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            targetPos = oriPos;
        }
        
    }
}

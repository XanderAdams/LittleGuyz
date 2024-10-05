using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigguymovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movepoint;

    // Start is called before the first frame update
    void Start()
    {
        movepoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movepoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movepoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                movepoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                movepoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }  
    }
}

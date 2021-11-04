using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float walkSpeed;
    public bool mustPatrol;
    private bool mustTurn;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public Transform killCheckPos;
    public LayerMask groundLayer;
    public LayerMask PlayerLayer;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.OverlapCircle(killCheckPos.position, 0.1f, PlayerLayer))
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f,groundLayer);
        }
    }

    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
    }
}

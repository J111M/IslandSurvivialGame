using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    //public Animator animator;
    private Transform player;
    private Vector2 target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float range;

    public float jumpTime;
    public float jumpStopTime;
    public bool jumpStopBool;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;

        jumpStopBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance1 = Vector3.Distance(transform.position, player.position);
        if (distance1 < range)
        {
            jumpTime += Time.deltaTime;

            if (jumpTime >= 1)
            {
                attackPlayer();

                jumpStopBool = true;
            }

            if (jumpStopBool == true)
            {
                jumpStopTime += Time.deltaTime;
            }

            if (jumpStopBool == false)
            {
                target = new Vector2(player.position.x, player.position.y);
            }

            if(jumpStopTime >= 2f)
            {
                jumpTime = 0;
                jumpStopTime = 0;
                jumpStopBool = false;
            }
            return;
        }

        
    }

    public void randomWalk()
    {
        //transform.position += transform.right * (Time.deltaTime * jumpForce);
    }

    public void attackPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void stopFollowing()
    {

    }
}

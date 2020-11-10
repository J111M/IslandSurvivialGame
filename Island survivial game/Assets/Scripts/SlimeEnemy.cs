using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    //public Animator animator;

    public Transform target;
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
        target = FindObjectOfType<PlayerMovement>().transform;

        jumpStopBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        jumpTime += Time.deltaTime;

        if(jumpTime >= 1)
        {
            attackPlayer();

            jumpStopBool = true;
        }

        if (jumpStopBool == true)
        {
            jumpStopTime += Time.deltaTime;
        }

        if(jumpStopTime >= 2f)
        {
            jumpTime = 0;
            jumpStopTime = 0;
            jumpStopBool = false;
        }


    }

    public void randomWalk()
    {
        //transform.position += transform.right * (Time.deltaTime * jumpForce);
    }

    public void attackPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void stopFollowing()
    {

    }
}

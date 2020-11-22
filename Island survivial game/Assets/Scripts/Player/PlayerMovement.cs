using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxStamina = 100;
    public float currentStamina;
    public float staminaRechargeTime = 4;

    public float runSpeed = 6f;
    public float moveSpeed = 4f;

    public Rigidbody2D rb;

    Vector2 movement;

    bool facingRight = true;

    bool sprint;

    bool isSprinting;
    bool staminaMin;
    bool notSprint;

    public Animator animator;

    public StaminaBar staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        staminaMin = false;
        currentStamina = maxStamina;
        sprint = true;
        isSprinting = false;
        staminaBar.setMaxStamina(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        

        animator.SetFloat("Speed", movement.sqrMagnitude);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");   

        

        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;

            staminaMin = false;
        }

        if(isSprinting == true)
        {
            staminaRechargeTime = 4;
            currentStamina -= 10 * Time.deltaTime;
            staminaBar.SetStamina(currentStamina);
        }

        if (staminaMin == true)
        {
            staminaRechargeTime -= 1 * Time.deltaTime;
            staminaBar.SetStamina(currentStamina);
        }


        if (Input.GetKey(KeyCode.LeftShift) && sprint == true && notSprint == false)
        {
            moveSpeed = runSpeed;

            staminaMin = false;

            isSprinting = true;

            staminaBar.SetStamina(currentStamina);
        }
        
        if(movement.sqrMagnitude <= 0)
        {
            notSprint = true;
        }
        else
        {
            notSprint = false;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 4f;

            staminaMin = true;

            isSprinting = false;

            staminaBar.SetStamina(currentStamina);
        }
        else if(sprint == false)
        {
            moveSpeed = 4f;

            isSprinting = false;

            staminaMin = true;

            staminaBar.SetStamina(currentStamina);
        }

        if(currentStamina <= 0)
        {
            staminaMin = true;

            currentStamina = 0;

            sprint = false;
        }

        if (currentStamina >= 1)
        {
            sprint = true;
        }
        
        if(staminaRechargeTime <= 0)
        {
            currentStamina += 10 * Time.deltaTime;

            staminaBar.SetStamina(currentStamina);
        }
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < transform.position.x && facingRight)
        {
            flip();
        }
        else if (mousePos.x > transform.position.x && !facingRight)
        {
            flip();
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
